﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    bool run;
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }
}