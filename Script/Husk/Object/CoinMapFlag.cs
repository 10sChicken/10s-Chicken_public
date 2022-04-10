using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMapFlag : MonoBehaviour
{
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private Transform[] coinPositions;
    private SpriteRenderer sr;
    private Collider2D coll;
    private int coinCount;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        SetFlag(false);

        coinCount = coinPositions.Length;
        for(int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(CoinPrefab, coinPositions[i].position, Quaternion.identity);
            coin.GetComponent<Coin>().CoinGetEvent += CoinGetCallBack;
        }
    }

    private void CoinGetCallBack()
    {
        coinCount--;
        if(coinCount > 0)   return;

        SetFlag(true);
    }

    private void SetFlag(bool input)
    {
        coll.enabled = input;
        sr.color = (input) ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    }

    
}
