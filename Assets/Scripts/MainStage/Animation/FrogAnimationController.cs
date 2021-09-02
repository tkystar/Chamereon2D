using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationController : MonoBehaviour
{

    public Animator animator;
    int n=0;
    float span;
    public bool moveani;
    private Vector2 input;
    bool stop;
    [SerializeField] private float SPEED=3.5f;
    Rigidbody2D rigidBody;
    frogtalkcontroller frogtalkcontroller;
    JustMove justmove;
    public bool frogMovingPermission=true;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        moveani = true;
        rigidBody = this.GetComponent<Rigidbody2D>();
        frogtalkcontroller = this.GetComponent<frogtalkcontroller>();
        justmove=frogtalkcontroller.camereon.GetComponent<JustMove>();
        frogMovingPermission = true;
    }

    // Update is called once per frame
    void Update()
    {
        //span+= Time.deltaTime;
        if(frogMovingPermission)
        {
            //Debug.Log("FDSFSDF");
            if (moveani)
            {
                moveani = false;

                if (n % 4 == 0)     ///forward
                {
                    animator.SetInteger("direction", 0);
                    Debug.Log("00");
                    input = new Vector2(0, -1.0f);
                    StartCoroutine("backtransition");

                }
                else if (n % 4 == 1)     ///left
                {
                    animator.SetInteger("direction", 1);
                    Debug.Log("22");
                    input = new Vector2(-1.0f, 0);
                    StartCoroutine("backtransition");
                }
                else if (n % 4 == 2)      ///back
                {
                    animator.SetInteger("direction", 2);
                    Debug.Log("11");
                    input = new Vector2(0, 1.0f);
                    StartCoroutine("backtransition");
                }
                else if (n % 4 == 3)      ///right
                {
                    animator.SetInteger("direction", 3);
                    Debug.Log("33");
                    input = new Vector2(1.0f, 0);
                    StartCoroutine("backtransition");
                }


                n++;
            }
        }
        

        if(frogtalkcontroller.talktrigger)
        {
            frogMovingPermission = false;
            //moveani = false;
            animator.SetBool("Stop", true);

            if (Mathf.Abs(frogtalkcontroller.camereon.transform.position.x-this.transform.position.x)< Mathf.Abs(frogtalkcontroller.camereon.transform.position.y - this.transform.position.y))
            {
                if (frogtalkcontroller.camereon.transform.position.y > this.transform.position.y)
                {
                    animator.SetInteger("talkdirection", 1);   //左向く
                }
                else
                {                   
                    animator.SetInteger("talkdirection", 3);   //↓向く
                }
            }
            else if(Mathf.Abs(frogtalkcontroller.camereon.transform.position.x - this.transform.position.x) >= Mathf.Abs(frogtalkcontroller.camereon.transform.position.y - this.transform.position.y))
            {
                
                if (frogtalkcontroller.camereon.transform.position.x > this.transform.position.x)
                {
                    animator.SetInteger("talkdirection", 4);   //右向く
                }
                else
                { 
                    animator.SetInteger("talkdirection", 2);   //左向く
                }
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (input == Vector2.zero)
        {
            
            return;
        }

        
        if (!stop)
        {
            
            rigidBody.position += input * SPEED;//NPCの移動  
            
            

        }
    }

    private IEnumerator backtransition()
    {
        yield return new WaitForSeconds(0.3f);
        stop = false;
        yield return new WaitForSeconds(0.4f);
        stop = true;
        yield return new WaitForSeconds(5.0f);
        //animator.SetInteger("direction", 5);
        moveani = true;
    }


}
