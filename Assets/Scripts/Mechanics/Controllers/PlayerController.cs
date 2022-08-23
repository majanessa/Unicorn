using UnityEngine;

namespace Unicorn.Mechanics.Controller
{

    public class PlayerController : MonoBehaviour
    {
        public AudioClip deathAudio;        

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float speed = 10f;
        
        public AudioSource audioSource;
        public Rigidbody2D rb;
        
        public bool controlEnabled = true;
        
        public Animator animator;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void OnMouseDrag()
        {
            if (controlEnabled) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                mousePos.x = mousePos.x > 2f ? 2f : mousePos.x;
                mousePos.x = mousePos.x < -2f ? -2f : mousePos.x;
                    
                transform.position = Vector2.MoveTowards(transform.position, 
                    new Vector3(mousePos.x, mousePos.y, transform.position.z), 
                    speed * Time.deltaTime);
            }
        }
    }
}
