using com.gdcbd.bossbattle.player;
using DG.Tweening;
using UnityEngine;

namespace com.gdcbd.bossbattle.utility
{
    public class DummyParryCoin : MonoBehaviour
    {
        private Collider2D objectCollider;
        private Rigidbody2D rigidbody2D;
        
        public float duration = 1f;
        public bool isRotated;
        private void Start()
        {
            objectCollider = GetComponent<Collider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            if(isRotated) ScaleToNegative();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") )
            {
                Vector2 collisionDirection = GetCollisionDirection(other);
                Debug.Log($"Collision Direction: {collisionDirection}");

                if (collisionDirection == Vector2.up)
                {
                    DOVirtual.DelayedCall(0.2f, () =>
                    {
                        objectCollider.enabled = false;
                        transform.DOScale(Vector3.zero, 1.0f).OnComplete(() =>
                        {
                            Destroy(gameObject);
                        });
                    });
                    other.gameObject.GetComponent<PlayerVisualController>().PowerUP();
                }
                else
                {
                    rigidbody2D.isKinematic = false;
                    other.gameObject.GetComponent<PlayerVisualController>().Hurt();
                }
            }else if (other.gameObject.CompareTag("Projectile"))
            {
                rigidbody2D.isKinematic = false;
            }
        }

        private Vector2 GetCollisionDirection(Collision2D collision)
        {
            ContactPoint2D contactPoint = collision.contacts[0];
            Vector2 collisionNormal = contactPoint.normal;

            return collisionNormal.y < 0 ? Vector2.up : Vector2.down;
        }
        
        void ScaleToNegative()
        {
            transform.DOScale(new Vector3(-1, 1, 1), duration).SetEase(Ease.InOutQuad).OnComplete(ScaleToPositive);
        }

        void ScaleToPositive()
        {
            transform.DOScale(new Vector3(1, 1, 1), duration).SetEase(Ease.InOutQuad).OnComplete(ScaleToNegative);
        }
        
    }
}