using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public Transform Joy;

    void Start()
    {

    }

    void Update()
    {
        Vector3 JoyCon = Joy.position;

        //左スティックでの縦移動
        //this.transform.position = JoyCon;
        this.gameObject.transform.position = new Vector3(JoyCon.x / 25f - 13f, JoyCon.y / 25f - 10.1f, JoyCon.z);
    }
}
