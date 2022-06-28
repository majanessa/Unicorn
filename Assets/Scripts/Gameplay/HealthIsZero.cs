using Unicorn.Core;
using Unicorn.Mechanics;
using static Unicorn.Core.Simulation;
using UnityEngine;

namespace Unicorn.Gameplay
{
    /// <summary>
    /// Fired when the player health reaches 0. This usually would result in a 
    /// PlayerDeath event.
    /// </summary>
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            Debug.Log("HealthIsZero");
            Schedule<PlayerDeath>();
        }
    }
}