using System;

namespace Root.UI.Scripts
{
    public static class UIEvents
    {
        public static event Action OnPlayerCollided;
        public static event Action OnLevelRestarted;

        public static void InvokeOnPlayerCollided()
        {
            OnPlayerCollided?.Invoke();
        }
        
        public static void InvokeOnLevelRestarted()
        {
            OnLevelRestarted?.Invoke();
        }
    }
}