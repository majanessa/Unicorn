using UnityEngine;
using System.Collections;

namespace Unicorn.Mechanics
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
                    Instantiate(playerWin, new Vector2(Random.Range (-2.5f, 2.5f), 5.9f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
	    }
    }
}