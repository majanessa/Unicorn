using Unicorn.Core;
using Unicorn.Mechanics.Scenes;
using Unicorn.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Unicorn.Mechanics.Controller
{
    public class UICoinAmountController : MonoBehaviour
    {
        private Text txt;
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
        private Level _level;
        public Text collectedCoins;

        void Start ()
        {
            _level = _model.scenesData.levels[_model.scenesData.CurrentLevelIndex - 1];
            txt = GetComponent <Text> ();
            PlayerPrefs.SetInt("Coins", 0);
            txt.text = PlayerPrefs.GetInt("Coins").ToString() + "/" + _level.NeedAmountCoin;
        }
    }
}
