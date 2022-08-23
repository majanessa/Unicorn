using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Unicorn.Mechanics.Controller
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class WinController : MonoBehaviour
    {
        public GameObject playerWin;
        void Start() {
            StartCoroutine(SpawnPlayerWin());
        }

        IEnumerator SpawnPlayerWin () {
            // Пока не проиграли постоянно создаем монеты
            while (true) {
                if (playerWin)
                    Instantiate(playerWin, new Vector2(Random.Range (-2f, 2f), 5.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
	    }

        private void OnMouseUp() {
            SceneManager.LoadScene ("Start");
        }

        private void OnTouchUp() {
            SceneManager.LoadScene ("Start");
        }
    }
}
