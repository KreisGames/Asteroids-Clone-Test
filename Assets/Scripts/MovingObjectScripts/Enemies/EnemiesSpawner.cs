using UnityEngine;

namespace MovingObjectScripts.Enemies
{
    public abstract class EnemiesSpawner : MonoBehaviour
    {

        [SerializeField] protected GameObject enemyToSpawn;
        public enum Side { Left = 0, Right = 1, Top = 2, Bottom = 3 }
        
        public abstract void CreateEnemy(Side side);

    }
}
