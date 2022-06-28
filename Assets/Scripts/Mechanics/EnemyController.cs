using System.Collections;
using System.Collections.Generic;
using Unicorn.Gameplay;
using UnityEngine;
using static Unicorn.Core.Simulation;
using Unicorn.Model;
using Unicorn.Core;

namespace Unicorn.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public AudioClip dead;
        internal Collider2D _collider;
        internal AudioSource audioSource;
        SpriteRenderer spriteRenderer;
        readonly GameModel model = Simulation.GetModel<GameModel>();


        void Awake()
        {
            _collider = GetComponent<Collider2D>();
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                if (this.audioSource && this.dead) {
                    if (player.controlEnabled)
                        this.audioSource.PlayOneShot(this.dead);
                }
            }
        }
    }
}