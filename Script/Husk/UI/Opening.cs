using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    private void Start()
    {
        if(Husk.SaveData.instance.seeOpening)
            this.gameObject.SetActive(false);
        
        Husk.SaveData.instance.seeOpening = true;
    }
}
