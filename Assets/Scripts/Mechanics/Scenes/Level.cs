using UnityEngine;
using System.Collections.Generic;

namespace Unicorn.Mechanics.Scenes
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
    public class Level : GameScene
    {
        // Настройки, относящиеся только к уровню
        [Header("Level specific")]
        [Tooltip("Ссылки на префабы")] [SerializeField]
        public List<GameObject> FallDownPrefabs;
        
        [Tooltip("Время между спауном")] [SerializeField]
        public float SpawnTime;

        [Tooltip("Необходимое количество монет для прохождения уровня")] [SerializeField]
        public int NeedAmountCoin;
    }
}
