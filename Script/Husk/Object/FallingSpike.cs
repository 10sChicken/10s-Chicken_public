using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    Rigidbody2D rigid;
    int layerMask;

    private void Start() 
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate() 
    {
        layerMask = 1 << LayerMask.NameToLayer("Player");
        RaycastHit2D playerIsUnder = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);
        if(playerIsUnder.collider != null){
            //TODO : 소리 트리거
            rigid.gravityScale = 2f;
        }
    }
}
