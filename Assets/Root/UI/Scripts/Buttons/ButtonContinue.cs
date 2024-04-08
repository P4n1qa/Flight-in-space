using UnityEngine;

namespace Root.UI.Scripts.Buttons
{
    public class ButtonContinue : AbstractButton
    {
        [SerializeField] private GameObject _pauseScreen;
        protected override void DoSmth()
        {
            PauseManager.UnPause();
            _pauseScreen.SetActive(false);
        }
    }
}