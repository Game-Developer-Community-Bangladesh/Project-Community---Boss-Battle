using UnityEngine;
using UnityEngine.Pool;

namespace com.gdcbd.bossbattle.components
{
    public class PoolObject : MonoBehaviour
    {
        public IObjectPool<GameObject> pool;

        private void OnDisable()
        {
            pool.Release(gameObject);
        }
    }
}