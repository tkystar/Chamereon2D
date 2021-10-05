using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleManager : MonoBehaviour
{
    public Fungus.Flowchart flowchart;
    Animator animator;
    //public GameObject eagle;
    private bool talktrigger;
    EagleAnimationController eagleanimationcontroller;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        eagleanimationcontroller = this.GetComponent<EagleAnimationController>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {

            flowchart.ExecuteBlock("Eagle");
            animator.SetBool("Stop", true);
            eagleanimationcontroller.talktrigger = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }*/
    ///thisline deleteok
    
}
