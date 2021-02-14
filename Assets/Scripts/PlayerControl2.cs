using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl2 : MonoBehaviour
{
    // 速度
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
    //Image CamereonIMG;
    //public Sprite CamereonIMG;
    public GameObject leftIMG;
    public GameObject rightIMG;
    public GameObject upIMG;
    public GameObject downIMG;
    public GameObject Camereon;
    private RectTransform hoge;
    public GameObject BodyObj;
    public GameObject BodyObj2;
    public GameObject BodyObj3;
    public GameObject BodyObj4;
    public Color Bodycolor;
    public int x1;
    public int y1;
    public int x2;
    public int y2;

    private Text timerText;
    public GameObject TextObj;
    private Transform NowPos;
    public Texture2D stage_texture;
    public Color TransitionColor;
    public Color startColor;
    public Color endColor;
    Color Leftcolor;
    Color Rightcolor;
    Color Upcolor;
    Color Downcolor;

    [Range(0f, 1f)]
    public float t;

    MeshRenderer cubeMeshRenderer;
    // Use this for initialization
    void Start()
    {
        
        hoge = this.GetComponent<RectTransform>();
        NowPos = Camereon.gameObject.GetComponent<Transform>();
        timerText = TextObj.GetComponent<Text>();

        //Bodycolor = BodyObj.GetComponent<Image>().color;
        

        //CamereonIMG = SetObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        Move();
        
        ColorCatch((int)NowPos.position.x, (int)NowPos.position.y);
        StopTime += Time.deltaTime;
        timerText.text = ((int)StopTime).ToString();
        TransitionColor = (Color.Lerp(startColor, endColor, StopTime / 3));
        BodyObj.GetComponent<Image>().color = TransitionColor;
        BodyObj2.GetComponent<Image>().color = TransitionColor;
        BodyObj3.GetComponent<Image>().color = TransitionColor;
        BodyObj4.GetComponent<Image>().color = TransitionColor;



    }

    // 移動関数
    void Move()
    {

        Vector2 Position = Camereon.GetComponent<RectTransform>().position;

        if (Input.GetKeyDown("left"))
        {
            leftIMG.SetActive(true);
            rightIMG.SetActive(false);
            upIMG.SetActive(false);
            downIMG.SetActive(false);
            startColor = TransitionColor;
            
            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyDown("right"))
        {
            leftIMG.SetActive(false);
            rightIMG.SetActive(true);
            upIMG.SetActive(false);
            downIMG.SetActive(false);
            startColor = TransitionColor;
            
            //hoge.sizeDelta = new Vector2(x2, y2);

        }
        else if (Input.GetKeyDown("up"))
        {
            leftIMG.SetActive(false);
            rightIMG.SetActive(false);
            upIMG.SetActive(true);
            downIMG.SetActive(false);
            startColor = TransitionColor;
            
            //hoge.sizeDelta = new Vector2(y1, x1);

        }
        else if (Input.GetKeyDown("down"))
        {
            leftIMG.SetActive(false);
            rightIMG.SetActive(false);
            upIMG.SetActive(false);
            downIMG.SetActive(true);
            startColor = TransitionColor;
            
            //hoge.sizeDelta = new Vector2(y1, x1);

        }




        if (Input.GetKey("left"))
        {


            Position.x -= SPEED.x;
            StopTime = 0;
        }
        else if (Input.GetKey("right"))
        {


            Position.x += SPEED.x;
            StopTime = 0;
        }
        else if (Input.GetKey("up"))
        {


            Position.y += SPEED.y;
            StopTime = 0;
        }
        else if (Input.GetKey("down"))
        {


            Position.y -= SPEED.y;
            StopTime = 0;
        }

        


        Camereon.transform.position = Position;
    }
    float StopTime;

    void Timer()
    {
        while (Input.GetKeyUp("left"))
        {
            StopTime += Time.deltaTime;
        }
        while (Input.GetKeyUp("right"))
        {
            StopTime += Time.deltaTime;
        }
        while (Input.GetKeyUp("up"))
        { // 上キーを押し続けていたら
            StopTime += Time.deltaTime;
        }
        while (Input.GetKeyUp("down"))
        {
            StopTime += Time.deltaTime;
        }
    }

    void ColorCatch(int x, int y)
    {
        endColor = stage_texture.GetPixel(x, y);
    }


}