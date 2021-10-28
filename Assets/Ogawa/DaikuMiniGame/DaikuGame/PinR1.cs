using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class PinR1 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image thisImage;

    Vector3 pos;

    public Sprite Pin0;
    public Sprite Pin1;
    public Sprite Pin2;
    public Sprite Pin3;
    public Sprite Pin4;
    public Sprite Pin5;
    public Sprite Pin6;
    public Sprite Pin7;
    public Sprite Pin8;
    // Start is called before the first frame update
    void Awake()
    {
        //pos = GetComponent<RectTransform>().position;
        pos = this.transform.position;
        thisImage = gameObject.GetComponent<Image>();
        Debug.Log(pos);
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        if (this.tag == "RedPin")
        {
            thisImage.sprite = Pin0;
        }
        if (this.tag == "GreenPin")
        {
            thisImage.sprite = Pin1;
        }
        if (this.tag == "BluePin")
        {
            thisImage.sprite = Pin2;
        }
        thisImage.rectTransform.sizeDelta = new Vector2(136f, 1211f);
        this.transform.position = new Vector2(pointerEventData.position.x, pointerEventData.position.y + 30f);
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        this.transform.position = new Vector2(pointerEventData.position.x, pointerEventData.position.y + 35f);
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        if (pointerEventData.position.x >= 123 && pointerEventData.position.x <= 332 &&
            pointerEventData.position.y >= 127 && pointerEventData.position.y <= 278)
        {
            this.transform.position = new Vector2(pointerEventData.position.x, pointerEventData.position.y + 30f);
            thisImage.rectTransform.sizeDelta = new Vector2(136f, 811f);
            if (this.tag == "RedPin")
            {
                thisImage.sprite = Pin3;
            }
            if (this.tag == "GreenPin")
            {
                thisImage.sprite = Pin4;
            }
            if (this.tag == "BluePin")
            {
                thisImage.sprite = Pin5;
            }

        }
        else
        {
            thisImage.rectTransform.sizeDelta = new Vector2(134f, 1688f);
            if (this.tag == "RedPin")
            {
                thisImage.sprite = Pin6;
            }
            if (this.tag == "GreenPin")
            {
                thisImage.sprite = Pin7;
            }
            if (this.tag == "BluePin")
            {
                thisImage.sprite = Pin8;
            }
            //GetComponent<RectTransform>().position = pos + new Vector3(9,-11,0);
            this.transform.position = pos;
        }
    }

}
