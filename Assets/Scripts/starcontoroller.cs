using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starcontoroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //StartCoroutine(Hoge());
        }


    }
    /*
    private IEnumarator Hoge()
    {
        yield return new WaitForSeconds(3.0f);

    }*/
}
