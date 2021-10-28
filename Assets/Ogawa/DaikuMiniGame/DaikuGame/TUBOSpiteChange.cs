using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TUBOSpiteChange : MonoBehaviour
{
    public GameObject PinBook;
    SpriteRenderer thisImage;
    public Sprite[] m_Sprites;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisImage = PinBook.GetComponent<SpriteRenderer>();
    }
    
    public void OnClick()
    {
        i = i + 1;
        if (i > 8)
        {
            i = 1;
        }
        thisImage.sprite = m_Sprites[i];
    }
}
