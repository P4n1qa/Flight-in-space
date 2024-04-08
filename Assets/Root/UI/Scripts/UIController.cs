using UnityEngine;

namespace Root.UI.Scripts
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIHitCounter _hitCounter;
        
        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            UIEvents.OnPlayerCollided += _hitCounter.UpdateCounter;
            UIEvents.OnLevelRestarted += _hitCounter.ResetToDefault;
        }
        
        private void UnSubscribe()
        {
            UIEvents.OnPlayerCollided -= _hitCounter.UpdateCounter;
            UIEvents.OnLevelRestarted -= _hitCounter.ResetToDefault;
        }
        
        private void OnDisable()
        {
            UnSubscribe();
        }
    }
}