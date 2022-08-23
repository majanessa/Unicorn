using Unicorn.Mechanics.Controller;
using Unicorn.Mechanics.Scenes;
using Unicorn.Model;
using UnityEngine;
using static Unicorn.Core.Simulation;

namespace Unicorn.Gameplay
{
    /// <summary>
    /// Fired when a Player collides with an Coin.
    /// </summary>
    public class PlayerCoinCollision : Event<PlayerCoinCollision>
    {
        public  UICoinAmountController coinAmountUI;

        private readonly GameModel _model = GetModel<GameModel>();

        public override void Execute()
        {
            Level level = _model.scenesData.levels[_model.scenesData.CurrentLevelIndex - 1];
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt ("Coins") + 1);
            coinAmountUI.collectedCoins.text = PlayerPrefs.GetInt ("Coins").ToString () + "/" + level.NeedAmountCoin;
            if (PlayerPrefs.GetInt ("Coins") == level.NeedAmountCoin)
                Schedule<PlayerWin>();
        }
    }
}
