using UnityEngine;

namespace Root.UI.Scripts.Buttons
{
    public class ButtonCloseLevel : AbstractButton
    {
        [SerializeField] private GameObject _startScreen;
        protected override void DoSmth()
        {
            SceneSystemManager.SceneSystemManager.UnloadGameScene();
            UIEvents.InvokeOnLevelRestarted();
            PauseManager.Pause();
            _startScreen.SetActive(true);
        }
    }
}