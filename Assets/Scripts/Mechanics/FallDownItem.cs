using System;
using UnityEngine;

namespace Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class FallDownItem : MonoBehaviour
    {
        protected AudioSource AudioSource;
        
        public static Action<GameObject> OnFallDownOverFly;

        [Tooltip("Falling speed")] [SerializeField]
         private float speed;

         protected virtual void Awake() {
             speed = UnityEngine.Random.Range(3f, 6f);
             AudioSource = GetComponentInParent<AudioSource>();
         }

         private void FixedUpdate()
         {
             transform.Translate(Vector3.down * (speed * Time.deltaTime));

             if (transform.position.y < -10 && OnFallDownOverFly != null)
                 OnFallDownOverFly(gameObject);
         }
    }
}
