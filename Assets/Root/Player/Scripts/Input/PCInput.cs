using UnityEngine;

namespace Root.Player.Scripts.Input
{
    public class PCInput : IInputSystem
    {
        public bool ButtonMovePressed()
        {
            return UnityEngine.Input.GetMouseButton(0);
        }

        public Vector3 TouchPosition()
        {
            return UnityEngine.Input.mousePosition;
        }
    }
}