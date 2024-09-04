using SixLabors.ImageSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AimBot_CS2
{
    // This class represents an entity in the game
    public class Entity
    {
        // Memory address of the pawn
        public IntPtr pawnAdress {  get; set; }
        // Memory address of the controller
        public IntPtr controllerAdress { get; set; }
        // Origin point of the entity
        public Vector3 origin {  get; set; }
        // View direction of the entity
        public Vector3 view { get; set; }
        // Position of the entity's head
        public Vector3 head { get; set; }
        // Current position of the entity
        public Vector3 position { get; set; }
        // 2D position of the entity (probably for UI)
        public Vector2 position2D { get; set; }
        // Offset from the entity's base to its view
        public Vector3 viewOffset { get; set; }
        // Position of the entity's view
        public Vector2 viewPosition { get; set; }
        // 2D position of the entity's view (probably for UI)
        public Vector2 viewPosition2D { get; set; }

        // Current health of the entity
        public int health { get; set; }
        // Team number of the entity
        public int team { get; set; }
        // Current life state of the entity (alive, dead, etc.)
        public int lifeState { get; set; }
        // Distance to this entity (probably from the player)
        public float distance  { get; set; }
    }
}