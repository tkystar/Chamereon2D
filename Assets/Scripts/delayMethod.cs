using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class delayMethod : MonoBehaviour
{
    int a = 0;
    bool yes=false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayMethod(3.5f, () =>
        {
            yes = true;
            //Debug.Log(a);
            //action();
        }));
    }

    // Update is called once per frame
    void Update()
    {
        if(yes)
        {
            Debug.Log("a");
        }
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    
}
