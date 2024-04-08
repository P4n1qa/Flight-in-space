using UnityEngine;

namespace Root.Pool
{
    public class AsteroidPool : AbstactPool
    {
        [SerializeField] private Asteroid.Scripts.Asteroid _asteroid;

        private PoolMono<Asteroid.Scripts.Asteroid> _poolAsteroids;
        protected override void CreatePool()
        {
            _poolAsteroids = new PoolMono<Asteroid.Scripts.Asteroid>(_asteroid, PoolCount, transform)
            {
                AutoExpand = AutoExpand
            };
        }

        public override GameObject TakeObjectFromPool()
        {
            var asteroid = _poolAsteroids.GetFreeElement();
            return asteroid.gameObject;
        }
    }
}