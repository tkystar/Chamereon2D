using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRangeColorChange : MonoBehaviour
{
    GameObject DragRange;
    SpriteRenderer rrend;
    byte alpha;
    bool cswith;
    // Start is called before the first frame update
    void Start()
    {
        DragRange = this.gameObject;
        rrend = DragRange.GetComponent<SpriteRenderer>();
        alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TongueAutoMove.drag_switch)
        {
            ChangeAphpa();
        }
        else if (TongueAutoMove.drag_switch)
        {
            rrend.color = new Color32(255, 255, 255, 0);
            alpha = 0;
        }
    }

    void ChangeAphpa()
    {
        if (alpha <= 0) cswith = false;
        if (alpha >= 100) cswith = true;
        if (!cswith)
        {
            alpha += 3;
        }
        if (cswith)
        {
            alpha -= 3;
        }
        rrend.color = new Color32(255, 255, 255, alpha);
    }
   
}
