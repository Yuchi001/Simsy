using System.Linq;
using NeedPack.Managers;
using NeedPack.So;
using PlayerPack;
using UnityEngine;

public class NeedObjectBehaviour : MonoBehaviour
{
    private SoNeedObjectRegen _needObjectInfo = null;
    
    private float _timer = 0;
    
    
    private void Setup(SoNeedObjectRegen needObjectInfo)
    {
        _needObjectInfo = needObjectInfo;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_needObjectInfo == null || _timer < 1) return;

        var allHitMembers = Physics2D.OverlapCircleAll(transform.position, _needObjectInfo.DetectionRange).ToList();
        foreach (var hitMember in allHitMembers)
        {
            if(!hitMember.TryGetComponent<PlayerMovement>(out var playerMovement)) continue;

            NeedsManager.Instance.IncrementNeedValue(_needObjectInfo.NeedObjectRegenType);
            _timer = 0;
        }
    }
}
