using UnityEngine;

namespace Gameplay.Player.Input.InputProviders
{
    public interface IInputProvider<out T> where T : struct
    {
        public T GetInputFrame();

        public void ConsumeInput();
    }
}