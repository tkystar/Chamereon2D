using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class PinR2 : MonoBehaviour
{
    private bool isDragging;
    private Vector3 thispos;

    SpriteRenderer thisImage;

    public Sprite Pin;
    public Sprite Sting;
    public Sprite Pick;

    public GameObject Serihu;
    SerihuChange SerihuChan;

    void Awake()
    {
        thisImage = gameObject.GetComponent<SpriteRenderer>();
        thispos = this.transform.position;
        SerihuChan = Serihu.GetComponent<SerihuChange>();
    }

    public void OnMouseDown()
    {
        isDragging = true;
        thisImage.sprite = Pick;
        if (-16.5f < this.transform.position.x && this.transform.position.x < -4.5f &&
            -6f < this.transform.position.y - 0 && this.transform.position.y - 0 < 4f)
        {
            SerihuChan.CountDown();
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;
        if (-16.5f < this.transform.position.x && this.transform.position.x < -4.5f &&
            -6f < this.transform.position.y - 0 && this.transform.position.y - 0 < 4f)
        {
            thisImage.sprite = Sting;
            SerihuChan.CountUp();
        }
        else
        {
            this.transform.position = thispos;
            thisImage.sprite = Pin;

        }
    }

    private void Update()
    {
        if (isDragging) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;// + new Vector3(0,2f,0);
            transform.Translate(mousePosition);
        }
    }

    public void ResetPin()
    {
        this.transform.position = thispos;
        thisImage.sprite = Pin;
        SerihuChan.CountDown();
    }
}
