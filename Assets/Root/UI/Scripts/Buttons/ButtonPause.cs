using UnityEngine;

namespace Root.UI.Scripts.Buttons
{
    public class ButtonPause : AbstractButton
    {
        [SerializeField] private GameObject _pauseScreen;

        protected override void DoSmth()
        {
            PauseManager.Pause();
            _pauseScreen.SetActive(true);
        }
    }
}
