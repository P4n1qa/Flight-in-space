using UnityEngine;

namespace ExternalAssets.Asteroids_Pack.Assets.Scripts
{
    public class RandomRotator : MonoBehaviour
    {
        [SerializeField]
        private float tumble;

        void Start()
        {
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        }
    }
}