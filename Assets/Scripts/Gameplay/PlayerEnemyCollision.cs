using static Unicorn.Core.Simulation;

namespace Unicorn.Gameplay
{
    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    public class PlayerEnemyCollision : Event<PlayerEnemyCollision>
    {
        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}
