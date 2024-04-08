using UnityEngine;

namespace Root.UI.Scripts.Buttons
{
    public class ButtonPlay : AbstractButton
    {
        [SerializeField] private GameObject _startScreen;
        [SerializeField] private GameObject _pauseScreen;
        
        protected override void DoSmth()
        {
            SceneSystemManager.SceneSystemManager.LoadGame();
            PauseManager.UnPause();
            _startScreen.SetActive(false);
            _pauseScreen.SetActive(false);
        }
    }
}