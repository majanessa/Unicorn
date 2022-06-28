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
    public class CoinController : MonoBehaviour
    {
        public AudioClip collectCoin;
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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player") {
                var player = other.gameObject.GetComponent<PlayerController>();
                if (player != null)
                {
                    if (this.audioSource && this.collectCoin) {
                        if (player.controlEnabled)
                            AudioSource.PlayClipAtPoint(this.collectCoin, new Vector2(0, 0), 2.0f);
                    }
                }
                var ev = Schedule<PlayerCoinCollision>();
                ev.coin = this;
            }
        }
    }
}