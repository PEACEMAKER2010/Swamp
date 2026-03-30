using Gameplay.Player.Input.Utility;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Gameplay.Player.Input.InputProviders
{
    public class PlayerInputProvider : MonoBehaviour, IInputProvider<PlayerInputFrame>
    {
        private const string k_playerMoveKey = "Player/Move";
        private const string k_playerShootKey = "Player/Shoot";

        [SerializeField] private PlayerInput playerInput;

        private InputAction m_playerMoveAction;
        private InputAction m_playerShootAction;

        private PlayerInputFrame _currentInputFrame;

        private void Awake()
        {
            Debug.Assert(playerInput != null, "PlayerInput component reference is missing!");
            SetInputs();
        }

        private void SetInputs()
        {
            m_playerMoveAction = playerInput.actions.FindAction(k_playerMoveKey, true);
            m_playerShootAction = playerInput.actions.FindAction(k_playerShootKey, true);
        }

        private void Update()
        {
            _currentInputFrame.MovementDirection = m_playerMoveAction.ReadValue<Vector2>();
            _currentInputFrame.Shoot = _currentInputFrame.Shoot.LoadFromInputAction(m_playerShootAction);
        }

        public PlayerInputFrame GetInputFrame()
        {
            return _currentInputFrame;
        }

        public void ConsumeInput()
        {
            _currentInputFrame.Consume();
        }
    }
}