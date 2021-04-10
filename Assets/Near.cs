using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Near : MonoBehaviour
{
    public GameObject Player;
    Transform Target;
    public GameObject camereon;
    public GameObject UIimage;
    bool once=true;
    // Start is called before the first frame update
    void Start()
    {
        Target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = (Target.position - camereon.transform.position).magnitude;
        //Debug.Log(distance);
        if (distance < 7&& once)
        {
            UIImageAppear();

            
        }else if(distance > 7)
        {
            once = true;
        }
    }
    void UIImageAppear()
    {
        UIimage.SetActive(true);
        once = false;
    }
}
