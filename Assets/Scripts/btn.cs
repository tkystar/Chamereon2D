using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn : MonoBehaviour
{
    
    [SerializeField] Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void leftbtn()
    {
       
        ani.SetBool("noburu", true);
    }

}
