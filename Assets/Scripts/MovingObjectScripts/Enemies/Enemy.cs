using UnityEngine;

namespace MovingObjectScripts.Enemies
{
    public class Enemy : MonoBehaviour
    {

        [SerializeField] protected int pointsOnDeath;
        
        [Tooltip("Starting speed of enemy")]
        [SerializeField] protected float speed;

        private void Update()
        {
            Move();
        }
        
        protected virtual void Move()
        {
            
        }

        // Destroys object, adds points. Override for additional things
        public virtual void Death()
        {
            Destroy(gameObject);
            ScoreSystem.IncreaseScore(pointsOnDeath);
        }
        
    }
}
