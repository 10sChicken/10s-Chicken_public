using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : MonoBehaviour
{
    [SerializeField] GameObject TimelineBlock;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            TimelineBlock.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
