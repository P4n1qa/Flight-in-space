using System.Collections;
using Root.Pool;
using UnityEngine;

namespace Root.ParticleSystem.Scripts
{
    public class PlayerHitParticle : MonoBehaviour, IPoolObject
    {
        [SerializeField] private float _lifeTime;
        private UnityEngine.ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<UnityEngine.ParticleSystem>();
        }

        public void Initialize(Vector3 spawn)
        {
            gameObject.transform.position = spawn;
            _particleSystem.Play();
            StartCoroutine(CR_DisableAfterTime());
        }

        private void OnDisable()
        {
            _particleSystem.Stop();
        }

        private IEnumerator CR_DisableAfterTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            gameObject.SetActive(false);
        }
    }
}