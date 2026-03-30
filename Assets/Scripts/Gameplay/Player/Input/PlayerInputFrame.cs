using UnityEngine;
using Gameplay.Player.Input.Utility;

namespace Gameplay.Player.Input
{
    public struct PlayerInputFrame : IConsumable
    {
        public Vector2 MovementDirection;

        public InputTrigger Shoot;

        public void Consume()
        {
            Shoot.Consume();
        }
        
    }
}