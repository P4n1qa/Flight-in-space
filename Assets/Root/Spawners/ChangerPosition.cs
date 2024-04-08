using UnityEngine;

namespace Root.Spawners
{
    public class ChangerPosition : MonoBehaviour
    {
        [SerializeField] private Transform _firstSpawner;
        [SerializeField] private Transform _secondSpawner;
        [SerializeField] private Transform _thirdSpawner;

        private const float offsetXPercentage = 0.1f;
        private const float offsetYPercentage = 0.1f;

        private float _screenWidth;
        private float _screenHeight; 

        private void Awake()
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;

            ChangePositionSpawner(-3f,_firstSpawner);
            ChangePositionSpawner(0f,_secondSpawner);
            ChangePositionSpawner(3f,_thirdSpawner);
        }
    
        private void ChangePositionSpawner(float horizontalOffset, Transform spawner)
        {
            float spawnPosX = _screenWidth * (0.5f + horizontalOffset * offsetXPercentage);
            float spawnPosY = _screenHeight * (1 - offsetYPercentage) + _screenHeight / 5f;

            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(spawnPosX, spawnPosY, 10f));

            spawner.position = spawnPosition;
        }
    }
}
