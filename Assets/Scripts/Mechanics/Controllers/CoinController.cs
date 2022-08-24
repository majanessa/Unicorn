using Core;
using Gameplay;
using Model;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Controllers
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
                    if (AudioSource && AudioSource.clip != null)
                        AudioSource.Play();
                    var ev = Schedule<PlayerCoinCollision>();
                    ev.CoinAmountUI = _model.coinAmountUI;
                    OnFallDownOverFly(gameObject);
                }
            }
        }
    }
}
