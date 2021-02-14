using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{
    // 速度
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
    Image CamereonIMG;
    public Sprite leftIMG;
    public Sprite rightIMG;
    public Sprite upIMG;
    public Sprite downIMG;
    private RectTransform hoge;
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
    [Range(0f, 1f)]
    public float t;
    
    MeshRenderer cubeMeshRenderer;
    // Use this for initialization
    void Start()
    {
        CamereonIMG = this.GetComponent<Image>();
        hoge = this.GetComponent<RectTransform>();
        NowPos = this.gameObject.GetComponent<Transform>();
        timerText = TextObj.GetComponent<Text>();
        
        //cubeMeshRenderer = cube.GetComponent<MeshRenderer>();
        //CamereonIMG.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        Move();
        /*
        ColorCatch((int)NowPos.position.x, (int)NowPos.position.y);
        StopTime += Time.deltaTime;
        timerText.text = ((int)StopTime).ToString();
        TransitionColor = (Color.Lerp(startColor, endColor, StopTime / 5));
        CamereonIMG.color = TransitionColor;
        */
        
    }

    // 移動関数
    void Move()
    {
        
        Vector2 Position = transform.position;
        
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

        if (Input.GetKeyDown("left"))
        {
            startColor = TransitionColor;
            CamereonIMG.sprite = leftIMG;
            hoge.sizeDelta = new Vector2(x2, y2);
            
        }
        else if (Input.GetKeyDown("right"))
        {
            startColor = TransitionColor;
            CamereonIMG.sprite = rightIMG;
            hoge.sizeDelta = new Vector2(x2, y2);
            
        }
        else if (Input.GetKeyDown("up"))
        {
            startColor = TransitionColor;
            CamereonIMG.sprite = upIMG;
            hoge.sizeDelta = new Vector2(y1, x1);
            
        }
        else if (Input.GetKeyDown("down"))
        {
            startColor = TransitionColor;
            CamereonIMG.sprite = downIMG;
            hoge.sizeDelta = new Vector2(y1, x1);
            
        }
        
       
        transform.position = Position;
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
        endColor = stage_texture.GetPixel(x,y);
    }
    


}