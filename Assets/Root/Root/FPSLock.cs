using UnityEngine;

namespace Root.Root
{
    public class FPSLock : MonoBehaviour
    {
        private void Awake()
        {
            SetupParameter();
        }

        private void SetupParameter()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}
