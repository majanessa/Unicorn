using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unicorn.Mechanics {

	// Скрипт для обработки кнопки Рестарт	
	public class Restart : MonoBehaviour {

		// При нажатии сделаем кнопку чуть побольше
		void OnMouseDown () {
			transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		}

		// Как отпустим мышь, то кнопка становиться поменьше
		void OnMouseUp () {
			transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		}

		// Перезапускаем игру при нажатии на кнопку
		void OnMouseUpAsButton () {
			SceneManager.LoadScene ("Main");
		}
	}
}
