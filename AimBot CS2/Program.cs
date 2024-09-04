using AimBot_CS2;
using Swed64;
using System.Numerics;
using System.Runtime.InteropServices;
using Vortice.Direct3D;

internal class Program
{
    private static void Main(string[] args)
    {
        // Initialize Swed with the game process name
        Swed swed = new("cs2");

        // Get the base address of the client.dll module
        nint client = swed.GetModuleBase("client.dll");

        // Create and start the renderer
        Renderer renderer = new Renderer();
        renderer.Start().Wait();

        // Initialize lists for entities and local player
        List<Entity> entities = new List<Entity>();
        Entity localPlayer = new Entity();

        // Define the hotkey for activating the aimbot (right Ctrl key)
        const int HOTKEY = 0xA3;

        // Main aimbot loop
        while (true)
        {
            entities.Clear();
            Console.Clear();

            // Get the entity list pointer
            nint entityList = swed.ReadPointer(client, Offsets.dwEntityList);
            nint listEntry = swed.ReadPointer(entityList, 0x10);

            // Read local player information
            localPlayer.pawnAdress = swed.ReadPointer(client, Offsets.dwLocalPlayerPawn);
            localPlayer.team = swed.ReadInt(localPlayer.pawnAdress, Offsets.m_iTeamNum);
            localPlayer.origin = swed.ReadVec(localPlayer.pawnAdress, Offsets.m_vOldOrigin);
            localPlayer.view = swed.ReadVec(localPlayer.pawnAdress, Offsets.m_vecViewOffset);

            // Loop through all possible entities
            for (int i = 0; i < 64; i++)
            {
                if (listEntry == nint.Zero)
                    continue;

                nint currentController = swed.ReadPointer(listEntry, i * 0x78);

                if (currentController == nint.Zero)
                    continue;

                // Get pawn handle
                int pawnHandle = swed.ReadInt(currentController, Offsets.m_hPlayerPawn);

                if (pawnHandle == 0)
                    continue;

                // Get specific pawn entry
                nint listEntry2 = swed.ReadPointer(entityList, 0x8 * ((pawnHandle & 0x7FFF) >> 9) + 0x10);
                nint currentPawn = swed.ReadPointer(listEntry2, 0x78 * (pawnHandle & 0x1FF));

                if (currentPawn == localPlayer.pawnAdress)
                    continue;

                // Get bone matrix for head position
                IntPtr sceneNode = swed.ReadPointer(currentPawn, Offsets.m_pGameSceneNode);
                IntPtr boneMatrix = swed.ReadPointer(sceneNode, Offsets.m_modelState + 0x80);

                // Read entity information
                int health = swed.ReadInt(currentPawn, Offsets.m_iHealth);
                int team = swed.ReadInt(currentPawn, Offsets.m_iTeamNum);
                int lifeState = swed.ReadInt(currentPawn, Offsets.m_lifeState);
                bool spotted = swed.ReadBool(currentPawn, Offsets.m_entitySpottedState + Offsets.m_bSpotted);

                // Skip entity if conditions are not met
                if (spotted == false && renderer.aimOnlyOnSpotted)
                    continue;
                if (lifeState != 256)
                    continue;
                if (team == localPlayer.team && !renderer.aimOnTeam)
                    continue;

                // Create and populate entity object
                Entity entity = new Entity();
                entity.pawnAdress = currentPawn;
                entity.controllerAdress = currentController;
                entity.health = health;
                entity.lifeState = lifeState;
                entity.origin = swed.ReadVec(currentPawn, Offsets.m_vOldOrigin);
                entity.view = swed.ReadVec(currentPawn, Offsets.m_vecViewOffset);
                entity.distance = Vector3.Distance(entity.origin, localPlayer.origin);
                entity.head = swed.ReadVec(boneMatrix, 6 * 32);

                entities.Add(entity);

                // Display entity information in console
                Console.ForegroundColor = (team != localPlayer.team) ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine($"{entity.health}hp, head coordinate ${entity.head}");
                Console.ResetColor();
            }

            // Sort entities by distance
            entities = entities.OrderBy(o => o.distance).ToList();

            // Perform aimbot if conditions are met
            if (entities.Count > 0 && GetAsyncKeyState(HOTKEY) < 0 && renderer.aimbot)
            {
                Vector3 playerView = Vector3.Add(localPlayer.origin, localPlayer.view);
                Vector3 entityView = Vector3.Add(entities[0].origin, entities[0].view);

                // Calculate new view angles
                Vector2 newAngles = Calculate.CalculateAngles(playerView, entities[0].head);
                Vector3 newAnglesVec3 = new Vector3(newAngles.Y, newAngles.X, 0.0f);

                // Write new view angles to memory
                swed.WriteVec(client, Offsets.dwViewAngles, newAnglesVec3);
            }

            // Sleep to reduce CPU usage
            Thread.Sleep(40);
        }
    }

    // Import Windows API function to check key state
    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey);
}