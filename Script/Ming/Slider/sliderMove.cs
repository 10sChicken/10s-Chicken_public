using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sliderMove : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Husk.Timer.instance.isTimerOn == true)
        {
            StartMove();
        }
        else
            StopMove();
    }

    #region 이동 관련
    void StartMove()
    {
        rigid.velocity = new Vector3(1.595f, 0f, 0f);
    }

    void StopMove()
    {
        rigid.velocity = Vector3.zero;
    }

    #endregion
}
