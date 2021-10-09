﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaikuTalkController : MonoBehaviour
{
    public Fungus.Flowchart flowchart;
    bool detectionTrigger;
    public GameObject camereon;
    JustMove justmove;
    Animator camereonanimator;
    public string talkcounter;
    Rigidbody2D rigidBody;
    bool talktrigger;
    private Vector2 dis;
    
    // Start is called before the first frame update
    void Start()
    {
        justmove = camereon.GetComponent<JustMove>();
        camereonanimator = camereon.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        detectionTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionTrigger)
        {
            dis = this.gameObject.transform.position - camereon.GetComponent<Transform>().position;

            if (dis.magnitude < 5)
            {
                talkstart();
                
            }
        }
        else
        {
            if (dis.magnitude > 8)
            {
                detectionTrigger = true;

            }
        }
    }

    void talkstart()
    {
        detectionTrigger = false;
        justmove.rb.velocity = new Vector2(0, 0);
        justmove.enabled = false;
        camereonanimator.SetInteger("camereonTransition", 7);
        
        flowchart.ExecuteBlock("Daiku");

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
        justmove.enabled = true;
       StartCoroutine("detectionTriggerOn");
        talkcounter = "firstfin";
    }

    private IEnumerator detectionTriggerOn()
    {
        yield return new WaitForSeconds(4.0f);

       
    }

    
}
