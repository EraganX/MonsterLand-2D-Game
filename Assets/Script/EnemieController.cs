using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    public float EnemieMoveSpeed;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(EnemieMoveSpeed,rigid.velocity.y);
    }
}
