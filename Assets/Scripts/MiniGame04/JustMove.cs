using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Camereon;
    [SerializeField] private int Speed;   
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public GameObject player;
    BoxCollider2D collider;
    Vector3 playertransform;
    Animator animator;
    float colliderbox_x;
    float colliderbox_y;
    public bool movinpermission;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collider = this.gameObject.GetComponent<BoxCollider2D>();
        playertransform=player.GetComponent<Transform>().transform.localScale;
        animator = this.GetComponent<Animator>();
        colliderbox_x=this.GetComponent<BoxCollider2D>().size.x;
        colliderbox_y= this.GetComponent<BoxCollider2D>().size.y;
        movinpermission = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movinpermission)
        {
            Move();
        }
    }

    void Move()
    {
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-Speed, 0);
            animator.SetInteger("camereonTransition", 2);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(Speed, 0);
            animator.SetInteger("camereonTransition", 3);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("up"))
        {
            rb.velocity = new Vector2(0, Speed);
            animator.SetInteger("camereonTransition", 0);

            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKey("down"))
        {
            rb.velocity = new Vector2(0, -Speed);
            animator.SetInteger("camereonTransition", 1);
            //hoge.sizeDelta = new Vector2(y1, x1);

        }



        if (Input.GetKeyUp("left"))
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 6);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("right"))
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 7);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("up"))
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 4);

            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKeyUp("down"))
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 5);
            //hoge.sizeDelta = new Vector2(y1, x1);
        }


        if (Input.GetKeyDown("left"))
        {

            //player.GetComponent<SpriteRenderer>().sprite = left;
            //player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider.size = new Vector2(colliderbox_y, colliderbox_x);

        }
        else if (Input.GetKeyDown("right"))
        {

            //player.GetComponent<SpriteRenderer>().sprite = left;
            //player.GetComponent<Transform>().transform.localScale = new Vector3(-1,1,1);
            collider.size = new Vector2(colliderbox_y, colliderbox_x);
        }
        else if (Input.GetKeyDown("up"))
        {

            // player.GetComponent<SpriteRenderer>().sprite = up;
            // player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider.size = new Vector2(colliderbox_x, colliderbox_y);
        }
        else if (Input.GetKeyDown("down"))
        {

            //player.GetComponent<SpriteRenderer>().sprite = down;
            //player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider.size = new Vector2(colliderbox_x, colliderbox_y);
        }
    }
}

