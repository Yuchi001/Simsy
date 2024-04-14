using UnityEngine;

namespace NeedPack.So.Needs
{
    [CreateAssetMenu(fileName = "new P1 need", menuName = "Custom/P1Need")]
    public class P1 : SoNeed
    {
        public override void OnNeedEmpty()
        {
            Debug.Log("You lost!");
        }
    }
}