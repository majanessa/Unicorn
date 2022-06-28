using System.Collections;
using System.Collections.Generic;
using Unicorn.Core;
using Unicorn.Model;
using UnityEngine;

namespace Unicorn.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        GameModel model = Simulation.GetModel<GameModel>();

        public override void Execute()
        {
            var player = model.player;
            // if (player.health.IsAlive)
            // {
                //player.health.Die();
                if (player.audioSource && player.deathAudio)
                    if (player.controlEnabled) {
                        player.audioSource.PlayOneShot(player.deathAudio);
                        player.controlEnabled = false;
                    }
                    player.animator.SetBool("Dead", true);
                    player.rb.gravityScale = 1;
                    model.restartButton.SetActive(true);
            // }
        }
    }
}