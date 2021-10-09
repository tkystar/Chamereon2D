using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMove : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Rigidbody2D rb3 = null;
    public GameObject Camereon;
    [SerializeField] private float Speed;
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public GameObject player;

    public GameObject mogura;

    BoxCollider2D collider;
    Vector3 playertransform;
    Vector3 moguratransform;

    Animator animator;
    float colliderbox_x;
    float colliderbox_y;
    public bool movinpermission2;

    public Vector2 old1;
    public Vector2 old2;
    public Vector2 old3;
    public Vector2 old4;

    List<Vector3> poslist = new List<Vector3>();
    List<GameObject> pllist = new List<GameObject>();
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = this.GetComponent<Rigidbody2D>();
        rb3 = mogura.GetComponent<Rigidbody2D>();
        collider = this.gameObject.GetComponent<BoxCollider2D>();
        playertransform = player.GetComponent<Transform>().transform.localScale;
        moguratransform = mogura.GetComponent<Transform>().transform.localScale;
        animator = this.GetComponent<Animator>();
        colliderbox_x = this.GetComponent<BoxCollider2D>().size.x;
        colliderbox_y = this.GetComponent<BoxCollider2D>().size.y;
        movinpermission2 = true;

        pllist.Add(mogura);
    }

    // Update is called once per frame
    void Update()
    {
        if (movinpermission2)
        {
            Move();
        }
        pos = this.transform.position;
        poslist.Insert(0,pos);
        while (pllist.Count < poslist.Count) poslist.RemoveAt(pllist.Count);
      
       for (int i = 0; i < poslist.Count; i++)
        {
            pllist[i].transform.position=(poslist[i]);
        }

    }

    void Move()
    {
        if (Input.GetKey("left"))
        {
            
            rb2.velocity = new Vector2(-Speed / Time.deltaTime, 0);
            animator.SetInteger("camereonTransition", 2);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("right"))
        {
            rb2.velocity = new Vector2(Speed / Time.deltaTime, 0);
            animator.SetInteger("camereonTransition", 3);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("up"))
        {
            rb2.velocity = new Vector2(0, Speed);
            animator.SetInteger("camereonTransition", 0);

            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKey("down"))
        {
            rb2.velocity = new Vector2(0, -Speed);
            animator.SetInteger("camereonTransition", 1);
            //hoge.sizeDelta = new Vector2(y1, x1);

        }



        if (Input.GetKeyUp("left"))
        {
            rb3.velocity = new Vector2(0, 0);
            rb2.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 6);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("right"))
        {
            rb3.velocity = new Vector2(0, 0);
            rb2.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 7);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("up"))
        {
            rb3.velocity = new Vector2(0, 0);
            rb2.velocity = new Vector2(0, 0);
            animator.SetInteger("camereonTransition", 4);

            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKeyUp("down"))
        {
            rb3.velocity = new Vector2(0, 0);
            rb2.velocity = new Vector2(0, 0);
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
    public void Stop()
    {
        rb2.velocity = Vector3.zero;
        animator.SetFloat("Forward", 0);
        animator.SetFloat("Turn", 0);
        animator.SetBool("Crouch", false);
    }

    public void OnAnimatorMove()
    {
        Vector2 oldPos = this.transform.position;
    }

     
}

