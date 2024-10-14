using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class MoveTriggerMessage : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private MessageHUD _messageHUD;
        [SerializeField] private string _message;

        private void Start()
        {
            _input.PointGrabbed += ShowMessage;
        }

        public void SetMessage(string message)
        {
            _message = message;
        }

        private void ShowMessage()
        {
            _messageHUD.ShowMessage(_message);
        }

        private void OnDestroy()
        {
            _input.PointGrabbed -= ShowMessage;
        }
    }
}