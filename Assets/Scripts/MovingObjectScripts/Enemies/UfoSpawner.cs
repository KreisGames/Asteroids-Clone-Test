using UnityEngine;

namespace MovingObjectScripts.Enemies
{
    public class UfoSpawner : EnemiesSpawner
    {

        public override void CreateEnemy(Side side)
        {
            var buf = Instantiate(enemyToSpawn);
            
            //z position is distance to camera
            var viewportSpawnPosition = new Vector3();     
            
            //Change spawn based on side
            switch (side)
            {
                case Side.Top:
                    viewportSpawnPosition = new Vector3(Random.Range(0f, 1f), 0.99f, 10);
                    break;
                case Side.Bottom:
                    viewportSpawnPosition = new Vector3(Random.Range(0f, 1f), 0.01f, 10);
                    break;
                case Side.Left:
                    viewportSpawnPosition = new Vector3(0.01f, Random.Range(0f, 1f), 10);
                    break;
                case Side.Right:
                    viewportSpawnPosition = new Vector3(0.99f, Random.Range(0f, 1f), 10);
                    break;
                default:
                    Debug.LogError("Side does not exist!");
                    break;
            }

            buf.transform.position = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        }
        
    }
}
