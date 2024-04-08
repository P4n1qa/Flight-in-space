using UnityEngine.SceneManagement;

namespace Root.SceneSystemManager
{
    public static class SceneSystemManager
    {
        public static void LoadGame()
        {
            SceneManager.LoadScene(SceneData.GameScene, LoadSceneMode.Additive);
        }

        public static void UnloadGameScene()
        {
            SceneManager.UnloadSceneAsync(SceneData.GameScene);
        }
    }
}