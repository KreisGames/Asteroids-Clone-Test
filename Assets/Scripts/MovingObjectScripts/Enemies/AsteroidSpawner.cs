using UnityEngine;

namespace MovingObjectScripts.Enemies
{
    public class AsteroidSpawner : EnemiesSpawner
    {

        public override void CreateEnemy(Side side)
        {
            var buf = Instantiate(enemyToSpawn);
            var moveDirection = new Vector3();
            
            //z position is distance to camera
            var viewportSpawnPosition = new Vector3();       
            
            //Change direction and spwnpoint based on side     
            switch (side)
            {
                case Side.Top:
                    moveDirection = new Vector3(Random.Range(-0.9f, 0.9f), -1, 0).normalized;
                    viewportSpawnPosition = new Vector3(Random.Range(0f, 1f), 0.99f, 10);
                    break;
                case Side.Bottom:
                    moveDirection = new Vector3(Random.Range(-0.9f, 0.9f), 1, 0).normalized;
                    viewportSpawnPosition = new Vector3(Random.Range(0f, 1f), 0.01f, 10);
                    break;
                case Side.Left:
                    moveDirection = new Vector3(1, Random.Range(-0.9f, 0.9f), 0).normalized;
                    viewportSpawnPosition = new Vector3(0.01f, Random.Range(0f, 1f), 10);
                    break;
                case Side.Right:
                    moveDirection = new Vector3(-1, Random.Range(-0.9f, 0.9f), 0).normalized;
                    viewportSpawnPosition = new Vector3(0.99f, Random.Range(0f, 1f), 10);
                    break;
                default:
                    Debug.LogError("Side does not exist!");
                    break;
            }

            buf.transform.position = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
            buf.GetComponent<Asteroid>().ChangeDirection(moveDirection);
        }
    }
}
