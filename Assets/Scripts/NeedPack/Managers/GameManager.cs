using System;
using System.Collections.Generic;
using System.Linq;
using NeedPack.Helpers;
using NeedPack.So;
using UnityEngine;

namespace NeedPack.Managers
{
    public class GameManager : MonoBehaviour
    {
       #region Singleton
       
       public static GameManager Instance { get; private set; }

       private void Awake()
       {
           if (Instance != null && Instance != this) Destroy(gameObject);
           else Instance = this;

           Init();
       }
       
       #endregion

       public bool InitiatedGameManager { get; private set; } = false;

       public List<SoNeed> NeedList { get; private set; }
       public List<SoNeedObjectRegen> RegenObjectList { get; private set; }

       private void Init()
       {
           InitiatedGameManager = false;
           
           NeedList = Resources.LoadAll<SoNeed>("SoNeeds").ToList();
           RegenObjectList = Resources.LoadAll<SoNeedObjectRegen>("SoNeedObjectRegen").ToList();

           InitiatedGameManager = true;
       }
    }
}