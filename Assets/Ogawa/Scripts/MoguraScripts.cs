using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoguraScripts : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public GameObject m1;

    Vector3 Trans;
    DateTime presentTime;
    public float span = 0.5f;
    private float currentTime = 0f;
    private float nowTime = 0f;
    bool FirstTime = false;

    List<Vector3> poslist = new List<Vector3>();
    List<GameObject> pllist = new List<GameObject>(); // プレイヤーのリスト



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey("left"))
        {
            poslist.Insert(0, this.transform.position);
            m1.transform.position = poslist[10];
            if (10 == poslist.Count)
            {
                
                for (int i = 0; i < 8; i++)
                {
                    poslist.RemoveAt(i);
                }
            }
            
        }
    }
}
//if (Input.GetKey("left"))
//{
//    // pos に先頭キャラが移動したい場所
//    poslist.Insert(0, this.transform.position);
//    // 必要のない座標を削除
//    while (pllist.Count * 10 < poslist.Count) poslist.RemoveAt(pllist.Count * 20);
//    // それぞれのプレイヤーを目標位置に移動
//    for (int i = 0; i < poslist.Count; i++)
//    {
//        for (int j = 0; j < poslist.Count * 10; j = j + 10)
//        {
//            pllist[i].transform.position = poslist[j];
//        }
//    }
//}
//if (Input.GetKey("right"))
//{
//    // pos に先頭キャラが移動したい場所
//    poslist.Insert(0, this.transform.position);
//    // 必要のない座標を削除
//    while (pllist.Count * 10 < poslist.Count) poslist.RemoveAt(pllist.Count * 10);
//    // それぞれのプレイヤーを目標位置に移動
//    for (int i = 0; i < poslist.Count; i++)
//    {
//        for (int j = 0; j < poslist.Count * 10; j = j + 10)
//        {
//            pllist[i].transform.position = poslist[j];
//        }
//    }
//}