using UnityEngine;

namespace Mechanics.Scenes
{
    public enum Type
    {
        MainMenu,
        RestartMenu
    }
 
    [CreateAssetMenu(fileName = "NewMenu", menuName = "Scene Data/Menu")]
    public class Menu : GameScene
    {
        // Menu settings
        [Header("Menu specific")]
        public Type type;
    }
}
