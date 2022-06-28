using Unicorn.Mechanics;
using UnityEngine;
using UnityEngine.UI;

namespace Unicorn.Model {

    [System.Serializable]
    public class GameModel
    {
        /// <summary>
        /// The camera in the scene.
        /// </summary>
        // public Camera camera;

        /// <summary>
        /// The main component which controls the player sprite, controlled 
        /// by the user.
        /// </summary>
        public PlayerController player;

        public EnemyController enemy;

        public CoinController coin;

        public Text collectedCoins;

        public Text record;

        public GameObject restartButton;
    }
}
