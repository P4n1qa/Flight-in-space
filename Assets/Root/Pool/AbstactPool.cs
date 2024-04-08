using UnityEngine;

namespace Root.Pool
{
    public abstract class AbstactPool : MonoBehaviour
    {
        public int PoolCount;
        public bool AutoExpand;

        private void Awake()
        {
            CreatePool();
        }

        protected abstract void CreatePool();

        public abstract GameObject TakeObjectFromPool();
    }
}
