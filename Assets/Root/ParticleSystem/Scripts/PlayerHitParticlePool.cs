using Root.Pool;
using UnityEngine;

namespace Root.ParticleSystem.Scripts
{
    public class PlayerHitParticlePool : AbstactPool
    {
        [SerializeField] private PlayerHitParticle _playerHitParticle;

        private PoolMono<PlayerHitParticle> _poolParticles;
        protected override void CreatePool()
        {
            _poolParticles = new PoolMono<PlayerHitParticle>(_playerHitParticle, PoolCount, transform)
            {
                AutoExpand = AutoExpand
            };
        }

        public override GameObject TakeObjectFromPool()
        {
            var asteroid = _poolParticles.GetFreeElement();
            return asteroid.gameObject;
        }
    }
}