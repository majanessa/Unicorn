using Gameplay;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Controllers
{
    public class EnemyController : FallDownItem
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player.controlEnabled && AudioSource && AudioSource.clip != null)
            {
                AudioSource.Play();
                Schedule<PlayerEnemyCollision>();
            }
        }
    }
}