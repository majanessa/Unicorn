using UnityEngine;

namespace Unicorn.Mechanics.Scenes
{
    public enum Type
    {
        MainMenu,
        RestartMenu
    }
 
    [CreateAssetMenu(fileName = "NewMenu", menuName = "Scene Data/Menu")]
    public class Menu : GameScene
    {
        // Настройки, относящиеся только к меню
        [Header("Menu specific")]
        public Type type;
    }
}
