using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    public event Action<int> LanguageChangeEvent;
    public void Korean()
    {
        // if (LanguageChangeEvent != null)
        // {
        //     LanguageChangeEvent(0);
        // }
        LanguageChangeEvent?.Invoke(0);
        Husk.SaveData.instance.playerData.langNo = 0;
    }
    public void English()
    {
        // if (LanguageChangeEvent != null)
        // {
        //     LanguageChangeEvent(1);
        // }
        LanguageChangeEvent?.Invoke(1);
        Husk.SaveData.instance.playerData.langNo = 1;
    }
}
