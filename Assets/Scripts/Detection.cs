
namespace Camereon2D
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Tilemaps;
    using UnityEngine.AI;

    
        public class Detection : MonoBehaviour
        {
            public GameObject HeartSprite;
            public GameObject TimeSprite;
            public GameObject timeTex;
            public GameObject CountDownTex;
            public GameObject gameoverUI;
            public GameObject clearUI;
            public GameObject Empty;
            public GameObject[] health;
            public GameObject[] star;
            private Text timetex;
            private Text countdowntex;
            public float RemainingTime = 60;
            float countdowntime = 4;
            public int healthlevel = 3;                            ///この値を参照してヘルス状態による処理を行う
            public int starlevel = 0;
            public bool start = false;

            /// </summary>
            // Start is called before the first frame update
            void Start()
            {
                timetex = timeTex.GetComponent<Text>();
                countdowntex = CountDownTex.GetComponent<Text>();
                //timeTex.SetActive(false);
                
            }

            // Update is called once per frame
            void Update()
            {
            /*
                countdowntime -= Time.deltaTime;
                countdowntex.text = ((int)countdowntime).ToString();

                if (countdowntime <= 1)
                {
                    start = true;
                    CountDownTex.SetActive(false);
                    timeTex.SetActive(true);
                }*/

            if (RemainingTime != 0)  // && start
            {
                RemainingTime -= Time.deltaTime;
            }

            timetex.text = ((int)RemainingTime).ToString();


            if (RemainingTime <=1 )
                {
                    timeTex.SetActive(false);
                    Debug.Log("22222");
                    gameoverUI.SetActive(true);
                }
            if (starlevel == 3)
            {
                clearUI.SetActive(true);
                timeTex.SetActive(false);
            }
            
            }
            public void OnCollisionEnter2D(Collision2D collision)
            {
                //Debug.Log(collision.gameObject.tag);

                if (collision.gameObject.tag == "heart")
                {
                    //Debug.Log("heartcollide");

                    if (healthlevel == 2)
                    {
                        health[2].SetActive(true);
                        healthlevel = 3;
                    }
                    else if (healthlevel == 1)
                    {
                        health[1].SetActive(true);
                        healthlevel = 2;
                    }
                }
                if (collision.gameObject.tag == "time")
                {
                    ///Debug.Log("timecollide");
                    if (RemainingTime < 55)
                    {
                        RemainingTime += 5;
                    }
                    else
                    {
                        RemainingTime = 60;
                    }

                }
                
                if (collision.gameObject.tag == "enemy")
                {
                    if (healthlevel == 3)
                    {
                        health[2].SetActive(false);
                        healthlevel = 2;
                    }
                    else if (healthlevel == 2)
                    {
                        health[1].SetActive(false);
                        healthlevel = 1;
                    }
                    else if (healthlevel == 1)
                    {
                        health[0].SetActive(false);
                        healthlevel = 0;
                        gameoverUI.SetActive(true);
                        timeTex.SetActive(false);

                    }


                }
                if (collision.gameObject.tag == "star")
                {
                if (starlevel == 0)
                {
                    star[0].SetActive(true);
                    starlevel = 1;
                }
                else if (starlevel == 1)
                {
                    star[1].SetActive(true);
                    starlevel = 2;
                }
                else if (starlevel == 2)
                {
                    star[2].SetActive(true);
                    starlevel = 3;                   
                }


            }
        }

        }
    
    

}

