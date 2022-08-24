using Core;
using Model;
using Mechanics.Scenes;
using UnityEngine;

namespace Mechanics.Controllers
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

        private void Awake()
        {
            GameObject background = GameObject.Find("Main Objects/Background");
            ScenesData scenesData = model.scenesData;
            background.GetComponent<SpriteRenderer>().sprite =
                scenesData.levels[scenesData.currentLevelIndex - 1].background;
        }

        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        private void Update()
        {
            if (Instance == this) Simulation.Tick();
        }
    }
}
