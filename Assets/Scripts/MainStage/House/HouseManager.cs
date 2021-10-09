#if !UNITY_2019_3_OR_NEWER
#define CINEMACHINE_PHYSICS_2D
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine.Utility;
using Cinemachine;

namespace Western
{

    public class HouseManager : MonoBehaviour
    {

        public GameObject Chamereon;
        Vector3 enterPos;
        Vector3 exitPos;
        public GameObject enterPosObject;
        public GameObject exitPosObject;

        public bool _stay;

        public bool isFadeIn = false;//フェードインするフラグ
        public bool isFadeOut = false;//フェードアウトするフラグ

        public float alpha = 0.0f;//透過率、これを変化させる
        public float fadeSpeed = 0.2f;//フェードに掛かる時間
        private GameObject _cam;
        public GameObject blackWall;
        
        HouseManager _houseManager;
        JustMove _justMove;

        public bool up = false;
        public bool down = false;
        public float dist;
        public CinemachineConfiner2D _cinemachineConfiner2D;
        // Start is called before the first frame update
        void Start()
        {
            enterPos = enterPosObject.GetComponent<Transform>().position;
            exitPos = exitPosObject.GetComponent<Transform>().position;
            _stay = false;
            this.GetComponent<BoxCollider2D>().enabled = true;
            _justMove = GameObject.Find("Camereon").GetComponent<JustMove>();
            _cinemachineConfiner2D=GameObject.Find("CM vcam2").GetComponent<CinemachineConfiner2D>();
        }

        // Update is called once per frame
        void Update()
        {
            dist = Vector3.Distance(enterPos, Chamereon.transform.position);

            if (_stay)
            {
               

                if (dist > 10.0f)
                {
                    this.GetComponent<BoxCollider2D>().enabled = true;
                }

            }

            if (isFadeIn)
            {
                alpha -= Time.deltaTime / fadeSpeed;
                if (alpha <= 0.0f)//透明になったら、フェードインを終了
                {
                    isFadeIn = false;
                    alpha = 0.0f;
                }
                blackWall.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }
            else if (isFadeOut)
            {
                alpha += Time.deltaTime / fadeSpeed;
                if (alpha >= 1.0f)//真っ黒になったら、フェードアウトを終了
                {
                    isFadeOut = false;
                    alpha = 1.0f;
                }
                blackWall.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }

            Move();
        }

        private void Move()
        {

            if (up)
            {
                _justMove.rb.velocity = new Vector2(0, 1);
                _justMove.animator.SetInteger("camereonTransition", 0);
                _justMove._renderer.sprite = _justMove.up;
                //hoge.sizeDelta = new Vector2(y1, x1);

            }
            else if (down)
            {
                _justMove.rb.velocity = new Vector2(0, -1.5f);
                _justMove.animator.SetInteger("camereonTransition", 1);
                _justMove._renderer.sprite = _justMove.down;
                //hoge.sizeDelta = new Vector2(y1, x1);

            }
            else if (!up)
            {
                _justMove.rb.velocity = new Vector2(0, 0);
                _justMove.animator.SetInteger("camereonTransition", 4);

                //hoge.sizeDelta = new Vector2(y1, x1);

            }
            else if (!down)
            {
                _justMove.rb.velocity = new Vector2(0, 0);
                _justMove.animator.SetInteger("camereonTransition", 5);

                //hoge.sizeDelta = new Vector2(y1, x1);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

            if (collision.gameObject.tag == ("Player"))
            {
               
                StartCoroutine("EnterHouse");
            }
        }



        public IEnumerator BackEnterHousePoslater()
        {
            yield return new WaitForSeconds(3.0f);
            _stay = true;
        }

        public IEnumerator EnterHouse()
        {
            _cinemachineConfiner2D.enabled=false;
            up = true;
            yield return new WaitForSeconds(0.5f);
            fadeOut();
            yield return new WaitForSeconds(1.0f);
            up = false;
            Chamereon.transform.position = exitPos;
            fadeIn();
            _stay = false;
        }

        public void fadeIn()
        {
            isFadeIn = true;
            isFadeOut = false;
        }

        public void fadeOut()
        {
            isFadeOut = true;
            isFadeIn = false;
        }
    }
}
