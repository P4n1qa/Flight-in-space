using Root.Player.Scripts;
using Root.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Root.Asteroid.Scripts
{
    public class Asteroid : MonoBehaviour,IPoolObject,IObjectWithParticles
    {
        [SerializeField]private float _rotationSpeedMin = 10f;
        [SerializeField]private float _rotationSpeedMax = 50f;
        [SerializeField]private float _fallSpeed = 5f;

        private Vector3 _rotationAxis;
        private float _rotationSpeed;
        private AbstactPool _particlePool;

        public void Initialize(Vector3 spawn)
        {
            transform.position = spawn;
            _rotationAxis = Random.onUnitSphere;
            _rotationSpeed = Random.Range(_rotationSpeedMin, _rotationSpeedMax);
        }

        public void Initialize(AbstactPool particlePool)
        {
            _particlePool = particlePool;
        }
        
        private void Update()
        {
            transform.Rotate(_rotationAxis, _rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime, Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ICanTakeDamage>() != null)
            {
                other.gameObject.GetComponent<ICanTakeDamage>().ApplyDamage();
                var particle = _particlePool.TakeObjectFromPool();
                particle.GetComponent<IPoolObject>().Initialize(transform.position);
                
                gameObject.SetActive(false);
            }
            else if (other)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
