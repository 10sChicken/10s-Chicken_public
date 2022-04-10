using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Credit : MonoBehaviour
{
    void OnEnable()
    {
        transform.DOLocalMoveY(1050, 7);
    }
    void OnDisable()
    {
        transform.DOKill();
        transform.localPosition = new Vector3(115, -550, 0);
    }
}
