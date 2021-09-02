using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogtalkcontroller : MonoBehaviour
{
    public Fungus.Flowchart flowchart;
    public  bool detectionTrigger;
    public GameObject camereon;
    JustMove justmove;
    Animator camereonanimator;
    string talkcounter;
    Rigidbody2D rigidBody;
    public bool talktrigger=false;
    FrogAnimationController froganimationcontroller;
    // Start is called before the first frame update
    void Start()
    {
        justmove = camereon.GetComponent<JustMove>();
        camereonanimator = camereon.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        detectionTrigger = true;
        froganimationcontroller = this.GetComponent<FrogAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (detectionTrigger)
        {
            Vector2 dis = this.gameObject.transform.position - camereon.GetComponent<Transform>().position;

            if (dis.magnitude < 5)
            {
                talkstart();
                Debug.Log("fff");

            }
        }
    }

    void talkstart()
    {
        detectionTrigger = false;
        justmove.rb.velocity = new Vector2(0, 0);
        justmove.movinpermission = false;
        camereonanimator.SetInteger("camereonTransition", 7);

        flowchart.ExecuteBlock("Hoody_Houkoku");

        

        talktrigger = true;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;


    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        detectionTrigger = false;
        justmove.rb.velocity = new Vector2(0, 0);
        justmove.enabled = false;
        camereonanimator.SetInteger("camereonTransition", 7);

        flowchart.ExecuteBlock("Daiku");

        Debug.Log("gd");

        talktrigger = true;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;

    }*/


    void talkfin()
    {
        talktrigger = false;
        rigidBody.constraints = RigidbodyConstraints2D.None;
        justmove.movinpermission = true;
        StartCoroutine("detectionTriggerOn");
        talkcounter = "firstfin";
        Debug.Log("fin");
        froganimationcontroller.animator.SetInteger("talkdirection", 0);
        froganimationcontroller.animator.SetBool("Stop", false);
        //froganimationcontroller.moveani = true;
        froganimationcontroller.frogMovingPermission = true;
    }



    private IEnumerator detectionTriggerOn()
    {
        yield return new WaitForSeconds(4.0f);

        detectionTrigger = true;
    }
}
