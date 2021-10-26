using UnityEngine;

namespace MovingObjectScripts.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        // Move player forward 
        public void MovePlayer(float speed)
        {
            _transform.position += _transform.TransformDirection(new Vector3(0, speed));
        }
        
        // Rotate player
        public void RotatePlayer(float rotation)
        {
            _transform.Rotate(0, 0, rotation);
        }
        
    }
}
