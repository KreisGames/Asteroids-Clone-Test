using UnityEngine;

namespace MovingObjectScripts.Enemies
{
    public class Asteroid : Enemy
    {

        private Vector3 _direction;
        
        //How many times this asteroid died already?
        private int _iteration;
        
        protected override void Move()
        {
            transform.position += _direction * Time.deltaTime * speed;
        }

        public override void Death()
        {
            if (_iteration < 3)
                SplitAsteroid();
            base.Death();
        }

        //After death asteroid will split in half
        private void SplitAsteroid()
        {
            _iteration++;
            var buf = Instantiate(gameObject);
            buf.GetComponent<Asteroid>().ChangeDirection(Quaternion.Euler(0, 0, 90) * _direction * 1.25f);
            buf.GetComponent<Asteroid>().SetIteration(_iteration);
            buf.transform.localScale *= 0.75f;
            buf = Instantiate(gameObject);
            buf.GetComponent<Asteroid>().ChangeDirection(Quaternion.Euler(0, 0, -90) * _direction * 1.25f);
            buf.GetComponent<Asteroid>().SetIteration(_iteration);
            buf.transform.localScale *= 0.75f;
        }

        public void ChangeDirection(Vector2 changeTo)
        {
            _direction = changeTo;
        }

        //Method to set iteration to clones
        private void SetIteration(int iteration)
        {
            _iteration = iteration;
        }

    }
}
