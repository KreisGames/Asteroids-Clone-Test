using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MovingObjectScripts.Enemies
{
    public class EnemiesManager : MonoBehaviour
    {

        [SerializeField] private float spawnDelay;
        
        private enum Enemies { Asteroid = 0, Ufo = 1 }
        
        private void Start()
        {
            StartCoroutine(SpawnWithDelay());
        }

        //Endless cycle, delay then spawn enemy
        private IEnumerator SpawnWithDelay()
        {
            yield return new WaitForSeconds(spawnDelay);
            var modeID = Random.Range(0, Enum.GetValues(typeof(Enemies)).Length);
            var mode = (Enemies) modeID;
            var side = (EnemiesSpawner.Side) Random.Range(0, Enum.GetValues(typeof(EnemiesSpawner.Side)).Length);
            
            //Choose which object to spawn and spawn it
            switch (mode)
            {
                case Enemies.Asteroid:
                    GetComponent<AsteroidSpawner>().CreateEnemy(side);
                    break;
                case Enemies.Ufo:
                    GetComponent<UfoSpawner>().CreateEnemy(side);
                    break;
                default:
                    Debug.LogError("Enemy does not exist!");
                    break;
            }

            //Loop
            StartCoroutine(SpawnWithDelay());
        }
    
    }
}
