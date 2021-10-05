using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamereonManager : MonoBehaviour
{
    public Fungus.Flowchart flowchart;
    private bool sabotendetection;
    private JustMove _justmove;
    // Start is called before the first frame update
    void Start()
    {
        _justmove = GetComponent<JustMove>();
        sabotendetection = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(sabotendetection)
        {
            if (collision.gameObject.name == "GoldenSaboten")
            {

                flowchart.ExecuteBlock("Saboten");
                _justmove.enabled = false;
            }
        }
        
    }

    private void talkfin()
    {
        StartCoroutine("talkfinCor");
        _justmove.enabled = true;
    }

    private IEnumerator talkfinCor()
    {
        sabotendetection = false;
        yield return new WaitForSeconds(3.0f);
        sabotendetection = true;
        
    }



}
