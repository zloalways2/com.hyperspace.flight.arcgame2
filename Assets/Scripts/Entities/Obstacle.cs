using UnityEngine;

namespace Entities
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] private float speed;

        public bool IsStopped { get; set; } = false;
        public bool IsPassed { get; set; } = false;

        private void FixedUpdate()
        {
            if (IsStopped)
                return;
            
            transform.position += Vector3.down * (speed * Time.fixedDeltaTime);
        }

        private void OnBecameInvisible()
        {
            Debug.Log("false");
            IsPassed = true;
        }
    }
}