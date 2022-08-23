using System.Collections;
using System.Collections.Generic;
using Unicorn.Core;
using UnityEngine;
using Unicorn.Mechanics.Scenes;
using Unicorn.Model;
using Random = UnityEngine.Random;

namespace Unicorn.Mechanics
{
    public class FallDownSpawner : MonoBehaviour
    {
        [Tooltip("Количество объектов в пуле")] [SerializeField]
        private int _poolCount;

        private static Dictionary<GameObject, FallDownItem> _fallDownItems;
        private Queue<GameObject> _currentPrefabs;
        
        [SerializeField]
        private ScenesData scenesData;

        private Level _level;
        
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
        
        private void Start()
        {
            _level = scenesData.levels[scenesData.CurrentLevelIndex - 1];
            _fallDownItems = new Dictionary<GameObject, FallDownItem>();
            _currentPrefabs = new Queue<GameObject>();
        
            for (int i = 0; i < _poolCount; i++)
            {
                var prefab = Instantiate(_level.FallDownPrefabs[Random.Range(0, _level.FallDownPrefabs.Count)]);
                var script = prefab.GetComponent<FallDownItem>();
                prefab.SetActive(false);
                _fallDownItems.Add(prefab, script);
                _currentPrefabs.Enqueue(prefab);
            }
            
            FallDownItem.OnFallDownOverFly += ReturnFallDown;
            
            StartCoroutine(Spawn());
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator Spawn()
        {
            if (_level.SpawnTime == 0)
            {
                Debug.LogError("Не выставлено время спауна, задано стандартное значение - 1сек.");
                _level.SpawnTime = 1;
            }
        
            while (_model.player.controlEnabled)
            {
                yield return new WaitForSeconds(_level.SpawnTime);
                if (_currentPrefabs.Count > 0)
                {
                    var prefab = _currentPrefabs.Dequeue();
                    prefab.SetActive(true);

                    float xPos = Random.Range(-1f, 2f);
                    prefab.transform.position = new Vector2(xPos, 6f);
                }
            }
        }
        
        private void ReturnFallDown(GameObject prefab)
        {
            prefab.transform.position = transform.position;
            prefab.SetActive(false);
            _currentPrefabs.Enqueue(prefab);
        }
    }
}
