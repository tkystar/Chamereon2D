using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraScripts : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public GameObject Player;
    bool C = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (C == true)
        {
            if (this.transform.position.x > Player.transform.position.x + 5f)
            {
                First1();
            }
            if (this.transform.position.x < Player.transform.position.x + 5f && this.transform.position.y > Player.transform.position.y + 5f)
            {
                First2();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            C = true;
        }
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
        animator.SetFloat("Forward", 0);
        animator.SetFloat("Turn", 0);
        animator.SetBool("Crouch", false);
    }

    public void First1()
    {
        
            rb.velocity = new Vector2(-15f, 0);
            animator.SetInteger("camereonTransition", 6);
    }

    public void First2()
    {
        
            rb.velocity = new Vector2(0, -15f);
            animator.SetInteger("camereonTransition", 5);
    
    }
}
