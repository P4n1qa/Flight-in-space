using Firebase;
using Firebase.Extensions;
using UnityEngine;

namespace Root.Firebase
{
    public class FireBaseInitialize : MonoBehaviour
    {
        public static FireBaseInitialize instance;
        
        private FirebaseApp _firebaseApp;
        
        private void Start()
        {
            InitializeFirebase();
        }

        private void InitializeFirebase()
        {
            if (instance == null)instance = this;
            
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => 
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available) 
                {
                    _firebaseApp = FirebaseApp.DefaultInstance;
                } 
                else 
                {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}\n" + 
                                   "Firebase Unity SDK is not safe to use here");
                }
            });
        }
    }
}
