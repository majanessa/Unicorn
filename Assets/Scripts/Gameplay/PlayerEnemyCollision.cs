using Unicorn.Core;
using UnityEngine;
using static Unicorn.Core.Simulation;
using Unicorn.Mechanics;

namespace Unicorn.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="PlayerEnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public PlayerController player;

        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}
