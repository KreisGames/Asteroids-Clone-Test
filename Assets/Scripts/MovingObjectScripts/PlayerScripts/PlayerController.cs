using System.Collections;
using MovingObjectScripts.Enemies;
using UnityEngine;

namespace MovingObjectScripts.PlayerScripts
{
    
    [RequireComponent(typeof(PlayerMovement), typeof(AmmoSystem))]
    public class PlayerController : MonoBehaviour
    {

        [Tooltip("Acceleration per second")] 
        [SerializeField] private float acceleration;

        [Tooltip("Rotation per second in degrees")] 
        [SerializeField] private float rotationSpeed;

        [SerializeField] private float maxSpeed;

        [SerializeField] private GameObject laserTexture;
        [SerializeField] private GameObject bullet;

        private PlayerMovement _thisPlayerMovement;
        private AmmoSystem _ammoSystem;
        private Transform _transform;
        private float _speed;

        private void Awake()
        {
            _thisPlayerMovement = GetComponent<PlayerMovement>();
            _ammoSystem = GetComponent<AmmoSystem>();
            _transform = transform;
        }

        private void Update()
        {
            //Accelerate on forward press, slow when not
            if (Input.GetAxis("Vertical") > 0)
            {
                _speed += acceleration * Time.deltaTime;
            }
            else
            {
                _speed -= acceleration * Time.deltaTime;
            }
            
            //Cap speed to never be less than 0 or more than max speed
            _speed = _speed < 0 ? 0 : _speed;
            _speed = _speed > maxSpeed ? maxSpeed : _speed;
            
            //Move player forward
            _thisPlayerMovement.MovePlayer(_speed * Time.deltaTime);
            
            //Rotate player
            _thisPlayerMovement.RotatePlayer(-Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
            
            //Fire laser
            if (Input.GetKeyDown(KeyCode.LeftShift) && _ammoSystem.GetCurrentAmmoCount() > 0)
            {
                FireLaser();
            }

            //Fire bullet
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireBullet();
            }
        }

        private void FireLaser()
        {
            _ammoSystem.UseAmmo();
            foreach (var target in Physics2D.RaycastAll(_transform.position, _transform.up))
            {
                if (target.collider.CompareTag("Enemy"))
                {
                    target.collider.GetComponent<Enemy>().Death();
                }
            }

            StartCoroutine(DrawLaser());
        }

        private void FireBullet()
        {
            var buf = Instantiate(bullet);
            buf.transform.position = _transform.position;
            buf.GetComponent<Bullet>().SetDirection(_transform.up);
        }
        
        //Getter for UI
        public float GetSpeed()
        {
            return _speed;
        }

        //Trick to show "laser", laser is child to player but not active
        private IEnumerator DrawLaser()
        {
            laserTexture.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            laserTexture.SetActive(false);
        }
        
    }
}
