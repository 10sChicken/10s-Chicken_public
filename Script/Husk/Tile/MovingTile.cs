using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float movingSpeed;
    private Transform toward;
    void Start()
    {
        transform.position = startPoint.position;
        toward = endPoint;
    }

    void Update()
    {
        if(!Husk.Timer.instance.isTimerOn)
            return;

        Vector2 offset = this.transform.position - toward.transform.position;
        if(offset.sqrMagnitude < 0.1f)
        {
            toward = (toward == endPoint) ? startPoint : endPoint;
        }

        transform.position = Vector2.MoveTowards(transform.position, toward.position, Time.deltaTime * movingSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
