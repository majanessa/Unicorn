using System;
using Unicorn.Core;
using Unicorn.Model;
using UnityEngine;

namespace Unicorn.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class FallDownItem : MonoBehaviour
    {
        protected AudioSource audioSource;
        
        public static Action<GameObject> OnFallDownOverFly;
        
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
         
         [Tooltip("Скорость падения")] [SerializeField]
         private float _speed;

         protected virtual void Awake() {
             _speed = UnityEngine.Random.Range(3f, 6f);
             audioSource = GetComponentInParent<AudioSource>();
         }

         private void FixedUpdate()
         {
             transform.Translate(Vector3.down * (_speed * Time.deltaTime));

             if (transform.position.y < -10 && OnFallDownOverFly != null)
                 OnFallDownOverFly(gameObject);
         }
    }
}
