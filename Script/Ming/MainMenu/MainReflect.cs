using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainReflect : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rigid.velocity = dir * Mathf.Max(speed, 2f);
    }
}
