using System.Collections;
using Unicorn.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unicorn.Core.Simulation;
using Unicorn.Core;

namespace Unicorn.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public GameModel model = Simulation.GetModel<GameModel>();

        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }

        void Start() {
            StartCoroutine(SpawnAxe());
            StartCoroutine(SpawnCoin());
        }

        IEnumerator SpawnAxe () {
            while (true) {
                // Пока не проиграли постоянно создаем топоры
                if (model.player.controlEnabled)
                    Instantiate(model.enemy, new Vector2(Random.Range (-2.5f, 2.5f), 5.9f), Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1f, 1.5f));
            }
	    }

        IEnumerator SpawnCoin () {
            while (true) {
                // Пока не проиграли постоянно создаем монеты
                if (model.player.controlEnabled)
                    Instantiate(model.coin, new Vector2(Random.Range (-2.5f, 2.5f), 5.9f), Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
	    }
    }
}