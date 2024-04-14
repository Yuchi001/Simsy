using NeedPack.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class NeedSlot : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI needNameTextField;

        [HideInInspector] public ENeedType needType;

        public Image FillImage => fillImage;
        public TextMeshProUGUI NeedNameTextField => needNameTextField;
    }
}