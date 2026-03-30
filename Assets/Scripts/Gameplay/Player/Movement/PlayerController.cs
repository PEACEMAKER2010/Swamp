using UnityEngine;
using Gameplay.Player.Input.InputProviders;
using Gameplay.Player.Input;

namespace Gameplay.Player.Movement
{
    public class PlayerController : MonoBehaviour
    {
        private IInputProvider<PlayerInputFrame> m_inputProvider;
        private PlayerMovement m_playerMovement;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_inputProvider = GetComponent<IInputProvider<PlayerInputFrame>>();
            m_playerMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            PlayerInputFrame inputFrame = m_inputProvider.GetInputFrame();
            m_playerMovement.Tick(inputFrame);
            m_inputProvider.ConsumeInput();
        }
    }
}
