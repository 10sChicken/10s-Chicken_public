using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMushroom : MonoBehaviour
{
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isRight;

    [Tooltip("치킨의 스피드는 2")]
    [SerializeField] private float movingSpeed;
    private Rigidbody2D rigid;
    private int movingDir = 1;
    private void Awake()
    {
        if(isRight) 
        {
            movingDir = 1;
        }
        else 
        {
            movingDir = -1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        if(!isMoving)   return;
        if(!Husk.Timer.instance.isTimerOn)  return;

        HorizontalMove();
    }

    private void HorizontalMove()
    {
        transform.Translate(Vector3.right * movingDir * Time.deltaTime * movingSpeed);
    }
}
