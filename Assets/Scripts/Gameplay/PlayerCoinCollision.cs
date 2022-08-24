using Mechanics.Controllers;
using Mechanics.Scenes;
using Model;
using UnityEngine;
using static Core.Simulation;

namespace Gameplay
{
    /// <summary>
    /// Fired when a Player collides with an Coin.
    /// </summary>
    public class PlayerCoinCollision : Event<PlayerCoinCollision>
    {
        public  UICoinAmountController CoinAmountUI;

        private readonly GameModel _model = GetModel<GameModel>();

        protected override void Execute()
        {
            Level level = _model.scenesData.levels[_model.scenesData.currentLevelIndex - 1];
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt ("Coins") + 1);
            CoinAmountUI.collectedCoins.text = PlayerPrefs.GetInt ("Coins").ToString () + "/" + level.needAmountCoin;
            if (PlayerPrefs.GetInt ("Coins") == level.needAmountCoin)
                Schedule<PlayerWin>();
        }
    }
}
