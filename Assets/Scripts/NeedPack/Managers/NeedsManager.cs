using System;
using System.Collections.Generic;
using System.Linq;
using NeedPack.Enums;
using NeedPack.Helpers;
using NeedPack.So;
using UnityEngine;

namespace NeedPack.Managers
{
    public class NeedsManager : MonoBehaviour
    {
        private List<SoNeedObjectRegen> _regenObjects = new();
        
        private readonly List<NeedsTuple> _needsTuple = new(); // aktywna lista needsów
        
        public static NeedsManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else Instance = this;

            _regenObjects = Resources.LoadAll<SoNeedObjectRegen>("SoNeedObjectRegen").ToList();

            foreach (var need in Resources.LoadAll<SoNeed>("SoNeeds"))
            {
                _needsTuple.Add(new NeedsTuple()
                {
                    need = need,
                    currentValue = need.MaxNeedValue,
                });
            }
        }

        public void IncrementNeedValue(ENeedObjectRegenType regenType)
        {
            var objectRegen = _regenObjects.FirstOrDefault(r => r.NeedObjectRegenType == regenType);
            if (objectRegen == default) return;

            var need = _needsTuple.FirstOrDefault(n => n.need.NeedType == objectRegen.PickedNeedType);
            if (need == default) return;

            need.currentValue = objectRegen.RegenValuePerSecond;
        }

        private void Update()
        {
            foreach (var needsTuple in _needsTuple)
            {
                needsTuple.currentValue -= needsTuple.need.DrainSpeed * Time.deltaTime;
                if (needsTuple.currentValue > 0) continue;
                
                needsTuple.need.OnNeedEmpty();
            }
        }
    }
}