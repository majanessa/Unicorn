using static Core.Simulation;

namespace Gameplay
{
    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    public class PlayerEnemyCollision : Event<PlayerEnemyCollision>
    {
        protected override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}
