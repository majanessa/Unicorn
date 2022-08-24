using Core;
using Model;
using Mechanics.Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics.Controllers
{
    public class UICoinAmountController : MonoBehaviour
    {
        private Text _txt;
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
        private Level _level;
        public Text collectedCoins;

        private void Start ()
        {
            _level = _model.scenesData.levels[_model.scenesData.currentLevelIndex - 1];
            _txt = GetComponent <Text> ();
            PlayerPrefs.SetInt("Coins", 0);
            _txt.text = PlayerPrefs.GetInt("Coins").ToString() + "/" + _level.needAmountCoin;
        }
    }
}
