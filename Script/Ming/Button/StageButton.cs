using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public int index;
    void Start()
    {

        if (Husk.SaveData.instance.playerData.stagesCleared[index - 1] == false)
        {
            Color color = GetComponent<Image>().color;
            color.a = 0.5f;
            GetComponent<Image>().color = color;
        }
    }
    public void SceneChange()
    {
        if (Husk.SaveData.instance.playerData.stagesCleared[index - 1] == true)
        {
            SceneManager.LoadScene(index);
        }
    }
}
