using Gameplay.Player.Input.Utility;

namespace Gameplay.Player.Movement
{
    public interface IMotor<in T> where T : IConsumable
    {
        public void Tick(T frame);
    }
}