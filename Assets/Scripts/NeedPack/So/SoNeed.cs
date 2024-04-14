using NeedPack.Enums;
using UnityEngine;

namespace NeedPack.So
{
    public abstract class SoNeed : ScriptableObject
    {
        [SerializeField] protected ENeedType needType;
        [SerializeField] protected EAnimationName animationName;
        [SerializeField] protected float maxNeedValue;
        [SerializeField] protected float drainSpeed;

        public ENeedType NeedType => needType;
        public EAnimationName AnimationName => animationName;
        public float MaxNeedValue => maxNeedValue;
        public float DrainSpeed => drainSpeed;

        public abstract void OnNeedEmpty();
    }
}
