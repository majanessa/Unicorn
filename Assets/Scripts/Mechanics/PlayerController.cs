using UnityEngine;
using Unicorn.Gameplay;
using static Unicorn.Core.Simulation;
using Unicorn.Model;
using Unicorn.Core;


namespace Unicorn.Mechanics {

    public class PlayerController : MonoBehaviour
    {
        public AudioClip healAudio;
        public AudioClip coinAudio;
        public AudioClip starAudio;
        public AudioClip axeAudio;
        public AudioClip deathAudio;        

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float speed = 10f;

        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        /*internal new*/ public Rigidbody2D rb;
        public Health health;
        public bool controlEnabled = true;

        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly GameModel model = Simulation.GetModel<GameModel>();

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void OnMouseDrag()
        {
            if (controlEnabled) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x > 0)
                    transform.localScale = new Vector2(-2, 2);
                else if (mousePos.x < 0)
                    transform.localScale = new Vector2(2, 2);
                    
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(mousePos.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            }
        }
    }
}
