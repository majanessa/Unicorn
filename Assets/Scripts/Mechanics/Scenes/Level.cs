using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Scenes
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
    public class Level : GameScene
    {
        // Level settings
        [Header("Background")]
        public Sprite background;
        
        [Header("Level specific")]
        [Tooltip("Links to prefabs")] [SerializeField]
        public List<GameObject> fallDownPrefabs;
        
        [Tooltip("Time between spawns")] [SerializeField]
        public float spawnTime;

        [Tooltip("The required number of coins to pass the level")] [SerializeField]
        public int needAmountCoin;
    }
}
