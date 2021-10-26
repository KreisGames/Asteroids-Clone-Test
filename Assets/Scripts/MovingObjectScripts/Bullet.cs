using System.Collections;
using MovingObjectScripts.Enemies;
using UnityEngine;

namespace MovingObjectScripts
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] private float speed;
        [SerializeField] private float lifetime;
    
        private Vector3 _direction;

        private void Start()
        {
            StartCoroutine(DestroyDelay());
        }

        //Move bullet in direction
        private void Update()
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }

        //Change direction of bullet, usually on bullet creation
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().Death();
                Destroy(gameObject);
            }
        }

        //Destroy bullet after some time if it doesn't hit anything
        private IEnumerator DestroyDelay()
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
        }
    }
}
