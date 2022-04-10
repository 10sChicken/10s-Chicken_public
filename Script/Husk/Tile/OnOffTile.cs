using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTile : MonoBehaviour
{
    private SpriteRenderer sr;
    private  BoxCollider2D coll;
    [SerializeField] private bool activeOnStart;
    private bool shouldChange;
    private Color normalColor = new Color(1f, 1f, 1f, 1f);
    private Color disabledColor = new Color(1f, 1f, 1f, .5f);

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        coll.enabled = activeOnStart;

        if(!activeOnStart)
        {
            sr.color = disabledColor;
        }
        
        sliderCheck[] sliders = FindObjectsOfType<sliderCheck>();
        sliders[0].OnOffTileEvent += SetTrigger;
        sliders[1].OnOffTileEvent += SetTrigger;
    }

    private void Update()
    {
        if(!Husk.Timer.instance.isTimerOn)  return;
        if(!shouldChange)   return;

        TriggerTile();
    }

    private void SetTrigger(bool input)
    {
        shouldChange = input;
    }

    private void TriggerTile()
    {
        activeOnStart = !activeOnStart;
        coll.enabled = activeOnStart;

        sr.color = (activeOnStart) ? normalColor : disabledColor;
        shouldChange = false;
    }
}
