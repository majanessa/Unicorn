using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Unicorn.Mechanics.Scenes
{
    [CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/Database")]
    public class ScenesData : ScriptableObject
    {
        public List<Level> levels = new List<Level>();
        public List<Menu> menus = new List<Menu>();
        public int CurrentLevelIndex = 1;

        /*
         * Уровни
         */

        // Загружаем сцену с заданным индексом
        public void LoadLevelWithIndex(int index)
        {
            if (index <= levels.Count)
            {
                // Загружаем сцену геймплея для уровня
                SceneManager.LoadSceneAsync("Gameplay");
                // Загружаем первую часть уровня в аддитивном режиме
                SceneManager.LoadSceneAsync("Level" + index.ToString(), LoadSceneMode.Additive);
            }
            // сбрасываем индекс, если у нас больше нет уровней
            else CurrentLevelIndex = 1;
        }

        // Запуск следующего уровня
        public void NextLevel()
        {
            CurrentLevelIndex++;
            if (CurrentLevelIndex > levels.Count)
            {
                LoadMainMenu();
            }

            LoadLevelWithIndex(CurrentLevelIndex);
        }

        // Перезапускаем текущий уровень
        public void RestartLevel()
        {
            LoadLevelWithIndex(CurrentLevelIndex);
        }

        // Новая игра, загрузка первого уровня
        public void NewGame()
        {
            LoadLevelWithIndex(1);
        }

        /*
         * Меню
        */

        // Загрузить главное меню
        public void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync(menus[(int)Type.MainMenu].sceneName);
        }

        // Загрузить меню паузы
        // public void LoadPauseMenu()
        // {
        //     SceneManager.LoadSceneAsync(menus[(int)Type.PauseMenu].sceneName);
        // }
        
        public void LoadRestartMenu()
        {
            SceneManager.LoadSceneAsync(menus[(int)Type.RestartMenu].sceneName, LoadSceneMode.Additive);
        }
    }
}
