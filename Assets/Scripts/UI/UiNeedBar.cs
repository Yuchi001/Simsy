using System;
using System.Collections.Generic;
using System.Linq;
using NeedPack.Managers;
using UnityEngine;

namespace UI
{
    public class UiNeedBar : MonoBehaviour
    {
        [SerializeField] private Transform slotListTransform;
        [SerializeField] private GameObject needSlotPrefab;

        private List<NeedSlot> _needSlots = new();
        
        private void Awake()
        {
            foreach (var need in GameManager.Instance.NeedList)
            {
                var slot = Instantiate(needSlotPrefab, slotListTransform.position, Quaternion.identity, slotListTransform);
                var slotScript = slot.GetComponent<NeedSlot>();
                _needSlots.Add(slotScript);

                slotScript.needType = need.NeedType;
                slotScript.NeedNameTextField.text = need.NeedType.ToString();
            }
        }

        private void Update()
        {
            foreach (var needTuple in NeedsManager.Instance.NeedsTuple)
            {
                var foundNeed = _needSlots.FirstOrDefault(n => n.needType == needTuple.need.NeedType);
                if (foundNeed == default) continue;
                
                foundNeed.FillImage.fillAmount = needTuple.currentValue / needTuple.need.MaxNeedValue;
            }
        }
    }
}