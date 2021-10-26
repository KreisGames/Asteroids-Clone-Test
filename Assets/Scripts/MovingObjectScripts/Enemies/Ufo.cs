using UnityEngine;

namespace MovingObjectScripts.Enemies
{
    public class Ufo : Enemy
    {
        private Vector3 _direction;
        private GameObject _player;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        //Move to player
        protected override void Move()
        {
            transform.position += _direction * Time.deltaTime * speed;
        }

        //Update direction so it always targets player
        private void FixedUpdate()
        {
            _direction = (_player.transform.position - transform.position).normalized;
        }
    }
}
