using System.Collections;
using System.Collections.Generic;
using Root.Asteroid;
using Root.Asteroid.Scripts;
using Root.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Root.Spawners
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private AbstactPool _asteroidPool;
        [SerializeField] private AbstactPool _particlePool;
        [SerializeField] private List<Transform> _spawns;
        [SerializeField] private float _maxTimeSpawn;
        [SerializeField] private float _minTimeSpawn;

        private Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(CR_SpawnAsteroid());
        }
        
        private IEnumerator CR_SpawnAsteroid()
        {
            var time = Random.Range(_minTimeSpawn, _maxTimeSpawn);
            yield return new WaitForSeconds(time);
            SpawnAsteroid();
            _coroutine = StartCoroutine(CR_SpawnAsteroid());
        }

        private void SpawnAsteroid()
        {
            var spawnerId = Random.Range(0, _spawns.Count);
            var asteroid = _asteroidPool.TakeObjectFromPool();
            asteroid.GetComponent<IPoolObject>().Initialize(_spawns[spawnerId].transform.position);
            asteroid.GetComponent<IObjectWithParticles>().Initialize(_particlePool);
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }
    }
}