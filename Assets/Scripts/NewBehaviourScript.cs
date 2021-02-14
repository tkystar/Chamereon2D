using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        double x = 0.0f;
        for(int y = 0; y < 100; y++)
        {
            x += 0.1f;
        }
        Debug.Log(x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
