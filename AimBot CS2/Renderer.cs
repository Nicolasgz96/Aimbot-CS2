using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AimBot_CS2;
using ClickableTransparentOverlay;
using ImGuiNET;

namespace AimBot_CS2
{
    // This class handles the rendering of the aimbot menu
    public class Renderer : Overlay
    {
        // Aimbot settings
        public bool aimbot = true; // Enable/disable aimbot
        public bool aimOnlyOnSpotted = false; // Aim only at spotted enemies
        public bool aimOnTeam = false; // Allow aiming at teammates

        // Override the Render method to create the aimbot menu
        protected override void Render()
        {
            // Begin a new ImGui window named "menu"
            ImGui.Begin("menu");

            // Create checkboxes for each aimbot setting
            ImGui.Checkbox("aimbot", ref aimbot); // Toggle aimbot on/off
            ImGui.Checkbox("aimOnTeam", ref aimOnTeam); // Toggle aiming at teammates
            ImGui.Checkbox("aimbotSpoted", ref aimOnlyOnSpotted); // Toggle aiming only at spotted enemies

            // Note: ImGui.End() is not called here, which might be an oversight
        }
    }
}