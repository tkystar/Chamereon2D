using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Camereon;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Position = Camereon.GetComponent<Transform>().position;

        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-120.0f, 0.0f);
            

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(120.0f, 0.0f);
            

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("up"))
        {
            rb.velocity = new Vector2(0.0f, 120.0f);
            

            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKey("down"))
        {
            rb.velocity = new Vector2(0.0f, -120.0f);
            
            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        if (Input.GetKeyUp("left"))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);


            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("right"))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);


            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("up"))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);


            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKeyUp("down"))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);

            //hoge.sizeDelta = new Vector2(y1, x1);
        }







            //Camereon.transform.position = Position;
        }

    }

