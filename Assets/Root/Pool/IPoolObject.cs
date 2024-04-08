using UnityEngine;

namespace Root.Pool
{
    public interface IPoolObject
    {
        public void Initialize(Vector3 spawn);
    }
}