using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Fungus;

//[RequireComponent(typeof(Flowchart))]
public class EagleAnimationController : MonoBehaviour
{
    [SerializeField]
    string message = "";
    GameObject playerObj;
    public Fungus.Flowchart flowchart;
    //playermove player;
    Animator eagleanimator;
    Animator camereonanimator;
    private Rigidbody2D rigidBody;
    [SerializeField]
    float span;//何秒毎に向きを変えるか
    float time;//タイマー変数
    private Vector2 input;
    public readonly float SPEED = 0.05f;
    int n = 0;
    AnimatorClipInfo clipInfo;
    public bool talktrigger;
    public GameObject camereon;
    private bool detectionTrigger;
    JustMove justmove;
    int talkcounter=0;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //player = playerObj.GetComponent<playermove>();
        eagleanimator = GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        detectionTrigger = true;
        justmove = camereon.GetComponent<JustMove>();
        camereonanimator = camereon.GetComponent<Animator>();
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            flowchart.ExecuteBlock("Eagle");
            Debug.Log("gd");
            animator.SetBool("Stop", true);
            talktrigger = true;
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            if (collision.gameObject.transform.position.x>this.transform.position.x)
            {
                animator.SetBool("right", true);
                animator.SetBool("left", false);
            }
            else if(collision.gameObject.transform.position.x <= this.transform.position.x)
            {                
                animator.SetBool("right", false);
                animator.SetBool("left", true);
            }
        }
    }
    */

    private void Update()
    {
        time += Time.deltaTime;
        if (time > span)
        {
            //int rand = Random.Range(0, 2);//移動する方向を決めます。]
            int rand = n % 2;
            clipInfo = eagleanimator.GetCurrentAnimatorClipInfo(0)[0];   // 引数はLayer番号、配列の0番目
            if (clipInfo.clip.name != "turnright")
            {
                switch (rand)
                {

                    case 0:
                        input = new Vector2(1.0f, 0);//右へ移動
                        this.eagleanimator.SetFloat("x", 1.0f);
                        //this.animator.SetFloat("y", 0f);
                        n++;
                        if (clipInfo.clip.name == "turnright")
                        {
                            Debug.Log("stopさせる");
                            break;
                        }
                        break;
                    case 1:
                        input = new Vector2(-1.0f, 0);//左へ移動
                        this.eagleanimator.SetFloat("x", -1.0f);
                        //this.animator.SetFloat("y", 0f);
                        n++;
                        if (clipInfo.clip.name == "turnright")
                        {
                            Debug.Log("stopさせる");
                            break;
                        }
                        break;


                }
            }
            

            time = 0;
        }
        

        if(detectionTrigger)
        {           
            Vector2 dis = this.gameObject.transform.position - camereon.GetComponent<Transform>().position;          

            if (dis.magnitude < 5)
            {
                talkstart();

            }
        }
        
        


    }

    void talkfin()
    {
        talktrigger = false;
        eagleanimator.SetBool("Stop", false);
        rigidBody.constraints = RigidbodyConstraints2D.None;
        justmove.enabled = true;
        StartCoroutine("detectionTriggerOn");
        talkcounter++;
    }

    private void FixedUpdate()
    {
        if (input == Vector2.zero)
        {
            Debug.Log("u");
            return;
        }

        Debug.Log("AnimationClip名 : " + clipInfo.clip.name);

        if (!talktrigger)
        {
            if(clipInfo.clip.name == "EagleWalk"|| clipInfo.clip.name == "Backeagle")
            {
                rigidBody.position += input * SPEED;//NPCの移動  
                Debug.Log(input);
            }
            
        }
    }

    private void talkstart()
    {
        detectionTrigger = false;
        justmove.rb.velocity = new Vector2(0, 0);
        justmove.enabled = false;
        camereonanimator.SetInteger("camereonTransition", 7);
        if (talkcounter == 0)
        {
            flowchart.ExecuteBlock("Eagle");
        }else if(talkcounter==1)
        {
            flowchart.ExecuteBlock("EagleTwice");
        }
        
        Debug.Log("gd");
        eagleanimator.SetBool("Stop", true);
        talktrigger = true;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;

        if (camereon.transform.position.x > this.transform.position.x)
        {
            eagleanimator.SetBool("right", true);
            eagleanimator.SetBool("left", false);
        }
        else if (camereon.transform.position.x <= this.transform.position.x)
        {
            eagleanimator.SetBool("right", false);
            eagleanimator.SetBool("left", true);
        }

    }
    /*
    IEnumerator Talk()
    {
        player.SetState(playermove.State.Talk);

        flowChart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);

        player.SetState(playermove.State.Normal);
    }*/
    IEnumerator detectionTriggerOn()
    {
       
        yield return new WaitForSeconds(3.0f);
        detectionTrigger = true;

    }
}
