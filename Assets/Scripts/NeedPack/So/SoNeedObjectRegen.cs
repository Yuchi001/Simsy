using NeedPack.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace NeedPack.So
{
    [CreateAssetMenu(fileName = "new Need Object Regen", menuName = "Custom/NedRegenerationObjecy")]
    public class SoNeedObjectRegen : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private ENeedType pickedNeedType;
        [SerializeField] private ENeedObjectRegenType needObjectRegenType;
        [SerializeField] private float regenValuePerSecond;
        [SerializeField] private float detectionRange;

        public float DetectionRange => detectionRange;
        public float RegenValuePerSecond => regenValuePerSecond;
        public ENeedType PickedNeedType => pickedNeedType;
        public ENeedObjectRegenType NeedObjectRegenType => needObjectRegenType;
        public Sprite Sprite => sprite;
    }
}