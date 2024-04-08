using UnityEngine;
using UnityEngine.UI;

namespace Root.UI.Scripts.Buttons
{
    public abstract class AbstractButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(DoSmth);
        }

        protected abstract void DoSmth();
    }
}