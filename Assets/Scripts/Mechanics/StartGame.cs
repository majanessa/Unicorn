using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unicorn.Mechanics {
	// Скрипт для обработки кнопки Старт
	
	public class StartGame : MonoBehaviour {

		//При нажатии сделаем кнопку чуть побольше
		void OnMouseDown () {
			transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		}

		// Как отпустим мышь, то кнопка становиться поменьше
		void OnMouseUp () {
			transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		}

		// Само действие
		// Говорим что переменная проигрыша равна false
		// и удаляем кнопку через 0.3 секунды
		void OnMouseUpAsButton () {
			SceneManager.LoadScene("Main");
		}
	}
}
