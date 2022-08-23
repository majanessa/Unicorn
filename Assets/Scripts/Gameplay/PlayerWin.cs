using Unicorn.Core;
using Unicorn.Mechanics;
using Unicorn.Model;
using UnityEngine.SceneManagement;

namespace Unicorn.Gameplay
{
    /// <summary>
    /// Fired when the player has win.
    /// </summary>
    public class PlayerWin : Simulation.Event<PlayerWin>
    {
        private readonly GameModel _model = Simulation.GetModel<GameModel>();

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Execute()
        {
            var player = _model.player;
            player.controlEnabled = false;
            player.gameObject.SetActive(false);
            SceneManager.LoadSceneAsync("Win Menu", LoadSceneMode.Additive);
            FallDownItem.OnFallDownOverFly = null;
        }
    }
}
