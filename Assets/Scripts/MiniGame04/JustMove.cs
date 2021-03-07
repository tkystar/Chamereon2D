using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Camereon;
    public int Speed;
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public GameObject player;
    BoxCollider2D collider;
    Vector3 playertransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collider = this.gameObject.GetComponent<BoxCollider2D>();
        playertransform=player.GetComponent<Transform>().transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-Speed, 0);


            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(Speed, 0);


            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("up"))
        {
            rb.velocity = new Vector2(0, Speed);


            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKey("down"))
        {
            rb.velocity = new Vector2(0, -Speed);

            //hoge.sizeDelta = new Vector2(y1, x1);

        }



        if (Input.GetKeyUp("left"))
        {
            rb.velocity = new Vector2(0, 0);


            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("right"))
        {
            rb.velocity = new Vector2(0, 0);


            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("up"))
        {
            rb.velocity = new Vector2(0, 0);


            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKeyUp("down"))
        {
            rb.velocity = new Vector2(0, 0);

            //hoge.sizeDelta = new Vector2(y1, x1);
        }


        if (Input.GetKeyDown("left"))
        {

            player.GetComponent<SpriteRenderer>().sprite = left;
            player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider.size = new Vector2(6, 3);

        }
        else if (Input.GetKeyDown("right"))
        {

            player.GetComponent<SpriteRenderer>().sprite = left;
            player.GetComponent<Transform>().transform.localScale = new Vector3(-1,1,1);
            collider.size = new Vector2(6, 3);
        }
        else if (Input.GetKeyDown("up"))
        {

            player.GetComponent<SpriteRenderer>().sprite = up;
            player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider.size = new Vector2(3, 6);
        }
        else if (Input.GetKeyDown("down"))
        {

            player.GetComponent<SpriteRenderer>().sprite = down;
            player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider.size = new Vector2(3, 6);
        }



    }
}

