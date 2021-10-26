using UnityEngine;

namespace MovingObjectScripts.PlayerScripts
{
    public  class AmmoSystem : MonoBehaviour
    {

        
        [SerializeField] private float reloadCooldown;
        [SerializeField] private int maxAmmo;

        //Remaining cooldown in seconds
        private float _currentCooldown;

        private int _ammoCount;

        private void Start()
        {
            _currentCooldown = reloadCooldown;
        }

        //Standard frame-based timer
        private void Update()
        {
            if (_ammoCount >= maxAmmo) return;
            _currentCooldown -= Time.deltaTime;
            if (_currentCooldown > 0) return;
            _ammoCount++;
            _currentCooldown = reloadCooldown;
        }

        //Getter for UI and fire check
        public int GetCurrentAmmoCount()
        {
            return _ammoCount;
        }

        
        //Getters for UI
        public int GetMaxAmmoCount()
        {
            return maxAmmo;
        }
        public float GetCooldown()
        {
            return _currentCooldown;
        }

        //Reduce ammo count after fire
        public void UseAmmo()
        {
            _ammoCount--;
            _currentCooldown = reloadCooldown;
        }

    }
}