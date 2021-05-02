using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiiaCatAnimationController : MonoBehaviour
{
    Animator animator;
    int n = 0;
    float span;
    bool ani;
    private Vector2 input;   
    [SerializeField] private float SPEED = 3.5f;
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        ani = true;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ani)
        {
            ani = false;

            if (n == 0)     ///stay
            {
                animator.SetInteger("Transition", 0);               
                StartCoroutine("backtransition");

            }
            else if (n == 1)      ///right
            {
                animator.SetInteger("Transition", 1);              
                StartCoroutine("backtransition");
            }
            else if (n == 2)     ///left
            {
                animator.SetInteger("Transition", 2);                
                StartCoroutine("backtransition");
            }
            else if (n == 3)      ///eye
            {
                animator.SetInteger("Transition", 3);               
                StartCoroutine("backtransition");
            }


           
        }
    }

    private IEnumerator backtransition()
    {
       
        yield return new WaitForSeconds(3.0f);
        n = Random.Range(0, 4);
        ani = true;
    }
}
