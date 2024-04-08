using TMPro;
using UnityEngine;

namespace Root.UI.Scripts
{
    public class UIHitCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hitCounter;

        private int _hitCount;

        public void UpdateCounter()
        {
            _hitCount += 1;
            _hitCounter.text = _hitCount.ToString();
        }

        public void ResetToDefault()
        {
            _hitCount = 0;
            _hitCounter.text = _hitCount.ToString();
        }
    }
}