using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugcontroller : MonoBehaviour
{
    private GameObject RootObject;
    private GameObject _child;

    private Vector3 b_pos;

    //private Vector3 b_w_scal;
    //private Vector3 b_l_scal;
   // private Vector3 p_scal;

    //private float b_velocity;
    [Header("獲得ポイント")]
    public int b_hp;
    private Vector3 t_pos;
    private bool normal;
    //private bool catch_switch;
   
    //private bool scal_switch;
   
    // Start is called before the first frame update
    void Start()
    {
        normal = true;
        b_pos = this.transform.position;
        
        //RootObject = GameObject.Find("tongue");
        //_child = RootObject.transform.Find("tonguehead").gameObject;
        //p_scal = RootObject.transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (normal)
        {
            b_pos.x -= Random.Range(0.01f, 0.05f);
            b_pos.y += Random.Range(-0.2f, 0.2f);
            DestroyBug();
            transform.position = b_pos;
        }

        /*if (catch_switch)
        {
            this.transform.localPosition = _child.transform.localPosition;
            /*if (scal_switch)
            {
                b_l_scal.x = b_w_scal.x / p_scal.x;
                b_l_scal.y = b_w_scal.y / p_scal.y;
                b_l_scal.z = b_w_scal.z / p_scal.z;
                this.transform.localScale = b_l_scal;
                scal_switch = false;
            }*/

            //Debug.Log();
            
        //}
    }

    void DestroyBug()
    {
        if (b_pos.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider t)
    {
        //Debug.Log(t.gameObject.tag);
        normal = false;
        //b_w_scal = this.transform.localScale;
        //this.transform.parent = RootObject.transform;

        //catch_switch = true;
        //scal_switch = true;
        

        buggenerator.b_sum += b_hp;
        buggenerator.b_point.text = buggenerator.b_sum.ToString();
        Destroy(this.gameObject);

    }
}
