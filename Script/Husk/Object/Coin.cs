using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Coin : MonoBehaviour
{
    public event Action CoinGetEvent = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // if(CoinGetEvent != null)
            //     CoinGetEvent();
            CoinGetEvent?.Invoke();
               
            this.gameObject.SetActive(false);
        }
    }
}
