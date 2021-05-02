using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationController : MonoBehaviour
{

    Animator animator;
    int n=0;
    float span;
    bool ani;
    private Vector2 input;
    bool stop;
    [SerializeField] private float SPEED=3.5f;
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
        //span+= Time.deltaTime;
        if (ani)
        {
            ani = false;
            
            if (n % 4 == 0)     ///forward
            {
                animator.SetInteger("direction", 0);
                Debug.Log("00");
                input = new Vector2(0,-1.0f);
                StartCoroutine("backtransition");
                
            }
            else if (n % 4 == 1)      ///back
            {
                animator.SetInteger("direction", 1);
                Debug.Log("11");
                input = new Vector2(0, 1.0f);
                StartCoroutine("backtransition");
            }
            else if (n % 4 == 2)     ///left
            {
                animator.SetInteger("direction", 2);
                Debug.Log("22");
                input = new Vector2(-1.0f, 0);
                StartCoroutine("backtransition");
            }
            else if(n%4==3)      ///right
            {
                animator.SetInteger("direction", 3);
                Debug.Log("33");
                input = new Vector2(1.0f, 0);
                StartCoroutine("backtransition");
            }

            
            n++;
        }
        
    }

    private void FixedUpdate()
    {
        if (input == Vector2.zero)
        {
            Debug.Log("u");
            return;
        }

        
        if (!stop)
        {
            
            rigidBody.position += input * SPEED;//NPCの移動  
            Debug.Log(input);
            

        }
    }

    private IEnumerator backtransition()
    {
        yield return new WaitForSeconds(0.3f);
        stop = false;
        yield return new WaitForSeconds(0.7f);
        stop = true;
        yield return new WaitForSeconds(3.0f);
        animator.SetInteger("direction", 5);
        ani = true;
    }


}
