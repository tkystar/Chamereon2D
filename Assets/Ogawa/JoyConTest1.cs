using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyConTest1 : MonoBehaviour
{
    public Transform Joy;
    private Vector3 FastPos;


    // Start is called before the first frame update
    void Start()
    {
        FastPos = Joy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Distance = Joy.transform.position - FastPos;
        this.gameObject.transform.position = new Vector3(Distance.x/18 + 3.6f,Distance.y/18,Distance.z/18) ;
    }
}
