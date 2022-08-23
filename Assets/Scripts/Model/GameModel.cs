using Unicorn.Mechanics.Controller;
using Unicorn.Mechanics.Scenes;

namespace Unicorn.Model {

    [System.Serializable]
    public class GameModel
    {
        /// <summary>
        /// The main component which controls the player sprite, controlled 
        /// by the user.
        /// </summary>
        public PlayerController player;

        public UICoinAmountController coinAmountUI;
        
        public ScenesData scenesData;
    }
}
