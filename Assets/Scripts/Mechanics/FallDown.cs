using UnityEngine;

// Скрипт что вешаем на кажду бомбочку
// Отвечает за их постоянное падание вниз
namespace Unicorn.Mechanics
{
	public class FallDown : MonoBehaviour {

		// [SerializeField]
		// private float fallSpeed = 3f;

		private float fallSpeed;

		void Awake() {
			fallSpeed = Random.Range(3, 6);
		}

		void Update() {
			if (transform.position.y < -6f)
				Destroy(gameObject);

			transform.position -= new Vector3 (0, fallSpeed * Time.deltaTime, 0);
		}
	}
}
