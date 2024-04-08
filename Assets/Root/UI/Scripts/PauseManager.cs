using UnityEngine;

namespace Root.UI.Scripts
{
    public static class PauseManager
    {
        public static void Pause()
        {
            Time.timeScale = 0;
        }
        
        public static void UnPause()
        {
            Time.timeScale = 1;
        }
    }
}