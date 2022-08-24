using System.Collections;
using System.Collections.Generic;
using Core;
using Mechanics.Scenes;
using Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics
{
    public class FallDownSpawner : MonoBehaviour
    {
        [Tooltip("Number of objects in the pool")] [SerializeField]
        private int poolCount;
        
        private static Dictionary<GameObject, FallDownItem> _fallDownItems;
        private Queue<GameObject> _currentPrefabs;
        
        [SerializeField]
        private ScenesData scenesData;

        private Level _level;
        
        private readonly GameModel _model = Simulation.GetModel<GameModel>();
        
        private void Start()
        {
            _level = scenesData.levels[scenesData.currentLevelIndex - 1];
            _fallDownItems = new Dictionary<GameObject, FallDownItem>();
            _currentPrefabs = new Queue<GameObject>();
        
            for (int i = 0; i < poolCount; i++)
            {
                var prefab = Instantiate(_level.fallDownPrefabs[Random.Range(0, _level.fallDownPrefabs.Count)]);
                var script = prefab.GetComponent<FallDownItem>();
                prefab.SetActive(false);
                _fallDownItems.Add(prefab, script);
                _currentPrefabs.Enqueue(prefab);
            }
            
            FallDownItem.OnFallDownOverFly += ReturnFallDown;
            
            StartCoroutine(Spawn());
        }
        
        private IEnumerator Spawn()
        {
            if (_level.spawnTime == 0)
            {
                _level.spawnTime = 1;
            }
        
            while (_model.player.controlEnabled)
            {
                yield return new WaitForSeconds(_level.spawnTime);
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
