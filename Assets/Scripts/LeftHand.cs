using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : ThrowingScript
{
    private RaycastHit hit;
    private Rigidbody rb;
    private Rigidbody bodyrb;
    public bool attached = false;
    private float momentum;
    public float speed;
    private float step;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bodyrb = body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(this.transform.position, new Vector3(-2, 1, 2), out hit))
            {
                attached = true;
                rb.isKinematic = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            attached = false;
            rb.isKinematic = false;
            rb.velocity = new Vector3(-2, 1, 2) * momentum;
        }
        if (attached)
        {
            momentum += Time.deltaTime * speed;
            step = momentum * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
        }
        if (!attached && momentum >= 0)
        {
            momentum -= Time.deltaTime * 5;
            step = 0;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        bodyrb.velocity= new Vector3(-2, 5, 1) * momentum;
        ThrowingBall();
    }
}
