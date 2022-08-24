using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics.Scenes
{
    [CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/Database")]
    public class ScenesData : ScriptableObject
    {
        public List<Level> levels = new List<Level>();
        public List<Menu> menus = new List<Menu>();
        public int currentLevelIndex = 1;
        
        /*
         * Levels
        */

        private void LoadLevelWithIndex(int index)
        {
            if (index <= levels.Count)
            {
                SceneManager.LoadSceneAsync("GamePlay");
            }
            else currentLevelIndex = 1;
        }
        
        public void NextLevel()
        {
            currentLevelIndex++;
            if (currentLevelIndex > levels.Count)
            {
                LoadMainMenu();
            }

            LoadLevelWithIndex(currentLevelIndex);
        }
        
        public void RestartLevel()
        {
            LoadLevelWithIndex(currentLevelIndex);
        }
        
        public void NewGame()
        {
            LoadLevelWithIndex(1);
        }

        /*
         * Menu
        */

        private void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync(menus[(int)Type.MainMenu].sceneName);
        }

        public void LoadRestartMenu()
        {
            SceneManager.LoadSceneAsync(menus[(int)Type.RestartMenu].sceneName, LoadSceneMode.Additive);
        }
    }
}
