using Unicorn.Core;
using Unicorn.Mechanics;
using Unicorn.Model;
using UnityEngine;
using static Unicorn.Core.Simulation;
using UnityEngine.SceneManagement;

namespace Unicorn.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Coin.
    /// </summary>
    /// <typeparam name="PlayerCoinCollision"></typeparam>
    public class PlayerCoinCollision : Simulation.Event<PlayerCoinCollision>
    {
        public CoinController coin;

        GameModel model = Simulation.GetModel<GameModel>();

        public override void Execute()
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt ("Coins") + 1);
            model.collectedCoins.text = PlayerPrefs.GetInt ("Coins").ToString () + "/" + 20;
            if (PlayerPrefs.GetInt ("Coins") == 20) {
                SceneManager.LoadScene ("Win");
            }
            UnityEngine.Object.Destroy(coin.gameObject);
        }
    }
}