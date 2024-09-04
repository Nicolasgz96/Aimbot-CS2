using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimBot_CS2
{
    public class Offsets
    {
        // offsets.cs
        // These are memory offsets for various game elements
       public static int dwCSGOInput = 0x1A28E50; // Offset for CS:GO input
       public static int dwEntityList = 0x19BEED0; // Offset for the entity list
       public static int dwGameEntitySystem = 0x1ADDBE8; // Offset for the game entity system
       public static int dwGameEntitySystem_highestEntityIndex = 0x1510; // Highest entity index in the game entity system
       public static int dwGameRules = 0x1A1C688; // Offset for game rules
       public static int dwGlobalVars = 0x1818648; // Offset for global variables
       public static int dwGlowManager = 0x1A1BD70; // Offset for the glow manager (probably for visual effects)
       public static int dwLocalPlayerController = 0x1A0E9C8; // Offset for the local player's controller
       public static int dwLocalPlayerPawn = 0x1824A18; // Offset for the local player's pawn
       public static int dwPlantedC4 = 0x1A261C8; // Offset for planted C4 explosives
       public static int dwPrediction = 0x18248D0; // Offset for prediction system
       public static int dwSensitivity = 0x1A1D358; // Offset for sensitivity settings
       public static int dwSensitivity_sensitivity = 0x40; // Specific offset for sensitivity value
       public static int dwViewAngles = 0x1A2E268; // Offset for view angles
       public static int dwViewMatrix = 0x1A20CF0; // Offset for view matrix
       public static int dwViewRender = 0x1A21488; // Offset for view rendering
       public static int dwWeaponC4 = 0x19C2960; // Offset for C4 weapon

        //Client.dll.cs
        // These are offsets for various entity properties

       public static int m_boneIndexAttached = 0xF48; // uint32 - Bone index for attachments
       public static int m_attachmentPointBoneSpace = 0xF50; // Vector - Attachment point in bone space
       public static int m_lifeState = 0x328; // uint8 - Current life state of the entity
       public static int m_hPlayerPawn = 0x7DC; // Handle to the player's pawn
       public static int m_iHealth = 0x324; // int32 - Current health of the entity
       public static int m_vOldOrigin = 0x1274; // Vector - Previous origin of the entity
       public static int m_iTeamNum = 0x3C3; // uint8 - Team number of the entity
       public static int m_vecViewOffset = 0xC50; // CNetworkViewOffsetVector - View offset
       public static int m_entitySpottedState = 0x10F8; // Entity spotted state
       public static int m_bSpotted = 0x8; // Whether the entity is spotted
       public static int m_modelState = 0x170; // Model state of the entity
       public static int m_pGameSceneNode = 0x308; // Pointer to the game scene node
    }
}