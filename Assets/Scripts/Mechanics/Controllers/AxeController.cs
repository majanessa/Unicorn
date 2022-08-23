using Unicorn.Gameplay;
using UnityEngine;
using static Unicorn.Core.Simulation;

namespace Unicorn.Mechanics.Controller
{
    public class AxeController : FallDownItem
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null && player.controlEnabled)
            {
                if (audioSource && audioSource.clip != null)
                    audioSource.Play();
                Schedule<PlayerEnemyCollision>();
            }
        }
    }
}
