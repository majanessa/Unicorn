using Model;
using Core;
using Mechanics;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
        private static readonly int Dead = Animator.StringToHash("Dead");

        protected override void Execute()
        {
            var player = _model.player;

            if (player.audioSource && player.deathAudio)
            {
                player.audioSource.PlayOneShot(player.deathAudio);
            }

            player.animator.SetBool(Dead, true);
            player.rb.gravityScale = 1;
            player.controlEnabled = false;
            _model.scenesData.LoadRestartMenu();
            FallDownItem.OnFallDownOverFly = null;
        }
    }
}
