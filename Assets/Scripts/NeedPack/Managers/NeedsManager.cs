using System;
using System.Collections;
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

        public List<NeedsTuple> NeedsTuple { get; private set; } = new(); // aktywna lista needsów

        public static NeedsManager Instance { get; private set; }

        private IEnumerator Start()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else Instance = this;

            yield return new WaitUntil(() => GameManager.Instance.InitiatedGameManager); 

            _regenObjects = GameManager.Instance.RegenObjectList;

            foreach (var need in GameManager.Instance.NeedList)
            {
                NeedsTuple.Add(new NeedsTuple()
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

            var need = NeedsTuple.FirstOrDefault(n => n.need.NeedType == objectRegen.PickedNeedType);
            if (need == default) return;

            need.currentValue = objectRegen.RegenValuePerSecond;
        }

        private void Update()
        {
            foreach (var needsTuple in NeedsTuple)
            {
                needsTuple.currentValue -= needsTuple.need.DrainSpeed * Time.deltaTime;
                if (needsTuple.currentValue > 0) continue;
                
                needsTuple.need.OnNeedEmpty();
            }
        }
    }
}