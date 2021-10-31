using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMove : MonoBehaviour
{
    public Rigidbody2D rb2;
    public GameObject Camereon;
    [SerializeField] public int Speed2;
    public Sprite left2;
    public Sprite right2;
    public Sprite up2;
    public Sprite down2;
    public GameObject player2;
    BoxCollider2D collider2;
    Vector3 playertransform2;
    public Animator animator2;
    float colliderbox_x2;
    float colliderbox_y2;
    public bool movinpermission2;
    public SpriteRenderer _renderer2;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = this.GetComponent<Rigidbody2D>();
        collider2 = this.gameObject.GetComponent<BoxCollider2D>();
        playertransform2 = player2.GetComponent<Transform>().transform.localScale;
        animator2 = this.GetComponent<Animator>();
        colliderbox_x2 = this.GetComponent<BoxCollider2D>().size.x;
        colliderbox_y2 = this.GetComponent<BoxCollider2D>().size.y;
        movinpermission2 = true;
        _renderer2 = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movinpermission2)
        {
            Move2();
        }
    }

    void Move2()
    {
        if (Input.GetKey("left"))
        {
            rb2.velocity = new Vector2(-Speed2 * Time.deltaTime, 0);
            animator2.SetInteger("camereonTransition", 2);
            _renderer2.sprite = left2;
            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("right"))
        {
            rb2.velocity = new Vector2(Speed2 * Time.deltaTime, 0);
            animator2.SetInteger("camereonTransition", 3);
            _renderer2.sprite = right2;
            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKey("up"))
        {
            rb2.velocity = new Vector2(0, Speed2 * Time.deltaTime);
            animator2.SetInteger("camereonTransition", 0);
            _renderer2.sprite = up2;
            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKey("down"))
        {
            rb2.velocity = new Vector2(0, -Speed2 * Time.deltaTime);
            animator2.SetInteger("camereonTransition", 1);
            _renderer2.sprite = down2;
            //hoge.sizeDelta = new Vector2(y1, x1);

        }



        if (Input.GetKeyUp("left"))
        {
            rb2.velocity = new Vector2(0, 0);
            animator2.SetInteger("camereonTransition", 6);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("right"))
        {
            rb2.velocity = new Vector2(0, 0);
            animator2.SetInteger("camereonTransition", 7);

            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyUp("up"))
        {
            rb2.velocity = new Vector2(0, 0);
            animator2.SetInteger("camereonTransition", 4);

            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKeyUp("down"))
        {
            rb2.velocity = new Vector2(0, 0);
            animator2.SetInteger("camereonTransition", 5);

            //hoge.sizeDelta = new Vector2(y1, x1);
        }


        if (Input.GetKeyDown("left"))
        {

            //player.GetComponent<SpriteRenderer>().sprite = left;
            //player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider2.size = new Vector2(colliderbox_y2, colliderbox_x2);

        }
        else if (Input.GetKeyDown("right"))
        {

            //player.GetComponent<SpriteRenderer>().sprite = left;
            //player.GetComponent<Transform>().transform.localScale = new Vector3(-1,1,1);
            collider2.size = new Vector2(colliderbox_y2, colliderbox_x2);
        }
        else if (Input.GetKeyDown("up"))
        {

            // player.GetComponent<SpriteRenderer>().sprite = up;
            // player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider2.size = new Vector2(colliderbox_x2, colliderbox_y2);
        }
        else if (Input.GetKeyDown("down"))
        {

            //player.GetComponent<SpriteRenderer>().sprite = down;
            //player.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);
            collider2.size = new Vector2(colliderbox_x2, colliderbox_y2);
        }
    }
}