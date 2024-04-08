using UnityEngine;

namespace Root.Player.Scripts.Input
{
    public interface IInputSystem
    {
        public bool ButtonMovePressed();
        public Vector3 TouchPosition();
    }
}