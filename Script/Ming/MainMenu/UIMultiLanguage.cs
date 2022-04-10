using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMultiLanguage : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string korText;

    [SerializeField]
    [TextArea]
    private string engText;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MainMenu>().LanguageChangeEvent += ChangeLanguage;

        if (Husk.SaveData.instance.playerData.langNo == 0)
            GetComponent<TextMeshProUGUI>().text = korText;
        else
            GetComponent<TextMeshProUGUI>().text = engText;
    }

    void ChangeLanguage(int langNo)
    {
        if (langNo == 0)
            GetComponent<TextMeshProUGUI>().text = korText;
        else
            GetComponent<TextMeshProUGUI>().text = engText;
    }
}
