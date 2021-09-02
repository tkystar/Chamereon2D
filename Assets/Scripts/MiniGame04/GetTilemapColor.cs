using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

namespace Pathfinding { 

    public class GetTilemapColor : MonoBehaviour
    {
        //public GameObject tile;
        public Sprite tate;
        public Sprite yoko;
        public Tilemap tile;
        public GameObject tiii;
        public GameObject player;
        public GameObject enemy;
        Vector3 Playerpos;
        Vector3 RUpos;
        Vector3 RDpos;
        Vector3 LUpos;
        Vector3 LDpos;
        //public Color CatchColor;

        [SerializeField] Color32 GREEN;   ///= new Color32(146,224,76,255);
        [SerializeField] Color32 YELLOW; ///= new Color32(253, 227, 83, 255);
        Rigidbody2D rb;
        public Color32 TransitionColor;
        public Color32 startColor;
        public Color32 endColor;
        float StopTime;
        public int Speed;
        public AIPath destinationscript;
        
        public GameObject TimeText;
        private Text time;
        
        public  float RGBDifference;
        public int a=10;
        //private Detection detection;
        BoxCollider2D collider;
        void Start()
        {
            //var tile = GameObject.FindObjectOfType<Tilemap>();
            rb = this.GetComponent<Rigidbody2D>();
            player.GetComponent<SpriteRenderer>().sprite = tate;
            AIPath destinationscript = enemy.GetComponent<AIPath>();
            time = TimeText.GetComponent<Text>();
            //detection = this.gameObject.GetComponent<Detection>();
            collider=this.gameObject.GetComponent<BoxCollider2D>();
            
        }

        // Update is called once per frame
        void Update()
        {
            
            StopTime += Time.deltaTime;
            getcolor();
            Move();
             RGBDifference= Mathf.Abs(endColor.r - startColor.r) + Mathf.Abs(endColor.g - startColor.g) + Mathf.Abs(endColor.b - startColor.b);
            if(startColor.r!=endColor.r&& startColor.g != endColor.g&& startColor.b != endColor.b)
            {
                TransitionColor = (Color32.Lerp(startColor, endColor, 765 * StopTime / a / RGBDifference));
            }
            
            player.GetComponent<SpriteRenderer>().color = TransitionColor;
            if (player.GetComponent<SpriteRenderer>().color == endColor)
            {
                Debug.Log("CLEAR");
                destinationscript.enabled = false;
            }
            else
            {
                destinationscript.enabled = true;
            }
        }

        public float width;
        public float height;
        //public Sprite spriteRU;
        void getcolor()
        {

            //var tile = GameObject.FindObjectOfType<Tilemap>();
            Playerpos = this.GetComponent<Transform>().position;
            //RUpos = this.GetComponent<Transform>().position;


            if (player.GetComponent<SpriteRenderer>().sprite == tate)
            {


                RUpos.x = Playerpos.x + width / 2;
                RUpos.y = Playerpos.y + height / 2;

                RDpos.x = Playerpos.x + width / 2;
                RDpos.y = Playerpos.y - height / 2;

                LUpos.x = Playerpos.x - width / 2;
                LUpos.y = Playerpos.y + height / 2;

                LDpos.x = Playerpos.x - width / 2;
                LDpos.y = Playerpos.y - height / 2;


            } else if (player.GetComponent<SpriteRenderer>().sprite == yoko)
            {


                RUpos.x = Playerpos.x + height / 2;
                RUpos.y = Playerpos.y + width / 2;

                RDpos.x = Playerpos.x + height / 2;
                RDpos.y = Playerpos.y - width / 2;

                LUpos.x = Playerpos.x - height / 2;
                LUpos.y = Playerpos.y + width / 2;

                LDpos.x = Playerpos.x - height / 2;
                LDpos.y = Playerpos.y - width / 2;

            }



            // Debug.Log(Playerpos);
            Vector3Int cellPosition = tile.WorldToCell(Playerpos);
            Vector3Int cellpositionRU = tile.WorldToCell(RUpos);
            Vector3Int cellpositionRD = tile.WorldToCell(RDpos);
            Vector3Int cellpositionLU = tile.WorldToCell(LUpos);
            Vector3Int cellpositionLD = tile.WorldToCell(LDpos);
            
            var sprite = tile.GetSprite(cellPosition);
            var spriteRU = tile.GetSprite(cellpositionRU);
            var spriteRD = tile.GetSprite(cellpositionRD);
            var spriteLU = tile.GetSprite(cellpositionLU);
            var spriteLD = tile.GetSprite(cellpositionLD);
            //tile.SetTile(cellPosition, null);     今いるタイルになにかする




            if (sprite.name == "Green" && spriteRU.name == "Green" && spriteRU.name == "Green" && spriteRD.name == "Green" && spriteLU.name == "Green" && spriteLD.name == "Green" && rb.velocity == new Vector2(0, 0)) //&& rb.velocity == new Vector2(0, 0)
            {
                endColor = GREEN;



            }
            else if (sprite.name == "Yellow" && spriteRU.name == "Yellow" && spriteRU.name == "Yellow" && spriteRD.name == "Yellow" && spriteLU.name == "Yellow" && spriteLD.name == "Yellow" && rb.velocity == new Vector2(0, 0))  //&&rb.velocity == new Vector2(0, 0)
            {
                endColor = YELLOW;


            }
        }
        float size_x;
        float size_y;

        void Move()
        {

            //Vector2 Position = Camereon.GetComponent<Transform>().position;

            if (Input.GetKey("left"))
            {
                rb.velocity = new Vector2(-Speed, 0);
                StopTime = 0;

                //hoge.sizeDelta = new Vector2(x2, y2);

            }
            else if (Input.GetKey("right"))
            {
                rb.velocity = new Vector2(Speed, 0);
                StopTime = 0;

                //hoge.sizeDelta = new Vector2(x2, y2);

            }
            else if (Input.GetKey("up"))
            {
                rb.velocity = new Vector2(0, Speed);
                StopTime = 0;

                //hoge.sizeDelta = new Vector2(y1, x1);

            }
            else if (Input.GetKey("down"))
            {
                rb.velocity = new Vector2(0, -Speed);
                StopTime = 0;
                //hoge.sizeDelta = new Vector2(y1, x1);

            }



            if (Input.GetKeyUp("left"))
            {
                rb.velocity = new Vector2(0, 0);


                //hoge.sizeDelta = new Vector2(x2, y2);

            }
            else if (Input.GetKeyUp("right"))
            {
                rb.velocity = new Vector2(0, 0);


                //hoge.sizeDelta = new Vector2(x2, y2);

            }
            else if (Input.GetKeyUp("up"))
            {
                rb.velocity = new Vector2(0, 0);


                //hoge.sizeDelta = new Vector2(y1, x1);

            }
            else if (Input.GetKeyUp("down"))
            {
                rb.velocity = new Vector2(0, 0);

                //hoge.sizeDelta = new Vector2(y1, x1);
            }


            if (Input.GetKeyDown("left"))
            {
                startColor = TransitionColor;
                player.GetComponent<SpriteRenderer>().sprite = yoko;
                collider.size = new Vector2(6, 3);
                
            }
            else if (Input.GetKeyDown("right"))
            {
                startColor = TransitionColor;
                player.GetComponent<SpriteRenderer>().sprite = yoko;
                collider.size = new Vector2(6, 3);
            }
            else if (Input.GetKeyDown("up"))
            {
                startColor = TransitionColor;
                player.GetComponent<SpriteRenderer>().sprite = tate;
                collider.size = new Vector2(3,6);
            }
            else if (Input.GetKeyDown("down"))
            {
                startColor = TransitionColor;
                player.GetComponent<SpriteRenderer>().sprite = tate;
                collider.size = new Vector2(3, 6);
            }





            //Camereon.transform.position = Position;
        }
    }
}

