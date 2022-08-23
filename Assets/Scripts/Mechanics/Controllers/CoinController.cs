using Unicorn.Core;
using Unicorn.Gameplay;
using Unicorn.Model;
using UnityEngine;
using static Unicorn.Core.Simulation;

namespace Unicorn.Mechanics.Controller
{
    public class CoinController : FallDownItem
    {
        private readonly GameModel _model = Simulation.GetModel<GameModel>();

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) {
                var player = other.gameObject.GetComponent<PlayerController>();
                if (player != null && player.controlEnabled)
                {
                    if (audioSource && audioSource.clip != null)
                        audioSource.Play();
                    var ev = Schedule<PlayerCoinCollision>();
                    ev.coinAmountUI = _model.coinAmountUI;
                    OnFallDownOverFly(gameObject);
                }
            }
        }
    }
}
