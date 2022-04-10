using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MultiLangText : MonoBehaviour
{
    [SerializeField] [TextArea]
    private string korText;

    [SerializeField] [TextArea]
    private string engText;
    void Start()
    {
        if(Husk.SaveData.instance.playerData.langNo == 0)
            GetComponent<TextMeshPro>().text = korText;
        else
            GetComponent<TextMeshPro>().text = engText;
    }
}
