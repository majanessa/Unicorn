using Model;
using Core;
using Mechanics;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    /// <summary>
    /// Fired when the player has win.
    /// </summary>
    public class PlayerWin : Simulation.Event<PlayerWin>
    {
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
        
        protected override void Execute()
        {
            var player = _model.player;
            player.controlEnabled = false;
            player.gameObject.SetActive(false);
            SceneManager.LoadSceneAsync("Win Menu", LoadSceneMode.Additive);
            FallDownItem.OnFallDownOverFly = null;
        }
    }
}
