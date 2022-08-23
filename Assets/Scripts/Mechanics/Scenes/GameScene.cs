using UnityEngine;

namespace Unicorn.Mechanics.Scenes
{
    public class GameScene : ScriptableObject
    {
        [Header("Information")]
        public string sceneName;
        public string shortDescription;
 
        [Header("Sounds")]
        public AudioClip music;
        [Range(0.0f, 1.0f)]
        public float musicVolume;
        
        [Header("Background")]
        public Sprite background;
    }
}
