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
    /// <typeparam name="PlayerWin"></typeparam>
    public class PlayerWin : Simulation.Event<PlayerWin>
    {
        GameModel model = Simulation.GetModel<GameModel>();

        public override void Execute()
        {
            
        }
    }
}