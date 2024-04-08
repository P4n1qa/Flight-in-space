using UnityEngine;

namespace Root.Player.Scripts.Input
{
    public class MobileInput : IInputSystem
    {
        public bool ButtonMovePressed()
        {
            return UnityEngine.Input.touchCount > 0;
        }

        public Vector3 TouchPosition()
        {
            Touch touch = UnityEngine.Input.GetTouch(0);
            return touch.position;
        }
    }
}