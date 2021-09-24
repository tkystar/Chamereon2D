using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimationController : MonoBehaviour
{
    Animator animator;
    bool escapetrigger;
    Rigidbody2D rigidBody;
    [SerializeField] float SPEED;
    CameraManager CameraManager;
    public GameObject GameManager;
    [SerializeField] float X;
    bool detectionTrigger;
    public GameObject camereon;
    JustMove justmove;
    Animator camereonanimator;
    public Fungus.Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        CameraManager = GameManager.GetComponent<CameraManager>();
        detectionTrigger = false;
        justmove = camereon.GetComponent<JustMove>();
        camereonanimator = camereon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (escapetrigger)
        {
            
                rigidBody.position += new Vector2(1,0) * SPEED;//NPCの移動  
            
            


        }
        if(this.transform.position.x>X&& this.transform.position.x < X+5)
        {
            CameraManager.switchDefCam();
            escapetrigger = false;
            this.gameObject.transform.position = new Vector2(310, 13);
            animator.SetBool("Stay", true);
            detectionTrigger = true;
        }

        

        if (detectionTrigger)
        {
            Vector2 dis = this.gameObject.transform.position - camereon.GetComponent<Transform>().position;

            if (dis.magnitude < 10)
            {
                talkstart();
                Debug.Log("fff");

            }
        }

    }

    public void escape()
    {
        Debug.Log("escape()");
        animator.SetBool("escape", true);
        escapetrigger = true;
        CameraManager.switchwolfCam();
    }

    private void talkstart()
    {
        detectionTrigger = false;
        justmove.rb.velocity = new Vector2(0, 0);
        justmove.enabled = false;
        camereonanimator.SetInteger("camereonTransition", 7);
        
        
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;

        if (camereon.transform.position.x > this.transform.position.x)
        {
            
        }
        else if (camereon.transform.position.x <= this.transform.position.x)
        {
            
        }

        flowchart.ExecuteBlock("WolfFirst");

    }

    void talkfin()
    {
        
        rigidBody.constraints = RigidbodyConstraints2D.None;
        justmove.enabled = true;
        StartCoroutine("detectionTriggerOn");
    }

    IEnumerator detectionTriggerOn()
    {

        yield return new WaitForSeconds(3.0f);
        detectionTrigger = true;

    }
}
