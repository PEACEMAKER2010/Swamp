using UnityEngine;
using UnityEngine.InputSystem;


namespace Gameplay.Player.Input.Utility
{
    public struct InputTrigger : IConsumable
    {
        public bool Pressed;
        public bool Held;
        public bool Released;
        
        public InputTrigger LoadFromInputAction(InputAction action)
        {
            Pressed |= action.WasPressedThisFrame();
            Released |= action.WasReleasedThisFrame();

            Held = action.IsPressed();
            return this;
        }

        public void Consume()
        {
            Pressed = false;
            Released = false;
        }
        
    }
}

