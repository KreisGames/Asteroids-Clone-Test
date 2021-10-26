using UnityEngine;

namespace MovingObjectScripts.PlayerScripts
{
    public class PlayerDestroyer : MonoBehaviour
    {

        private bool _deathState;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Hit!");
            if (other.CompareTag("Enemy"))
            {
                _deathState = true;
            }
        }
        
        //Getter for GameManager
        public bool GetDeathState()
        {
            return _deathState;
        }
        
    }
}
