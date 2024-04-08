using UnityEngine;

namespace Root.Root
{
    public class GameRoot : MonoBehaviour
    {
        public static GameRoot Instance{ get; private set; }
        
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (Instance != null && Instance != this)  
            {  
                Destroy(gameObject);
                return;
            }
            
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }
}
