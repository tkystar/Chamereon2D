using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Western
{

    public class ExitHouse : MonoBehaviour
    {
        public GameObject chamereon;
        public GameObject spawnPosObj; //enterhouse
        Vector3 _backPos;
        HouseManager housemanager;
        bool _stay;
        // Start is called before the first frame update
        void Start()
        {
            _backPos = spawnPosObj.GetComponent<Transform>().position;
            this.GetComponent<CircleCollider2D>().enabled = false;
            housemanager=spawnPosObj.GetComponent<HouseManager>();
            _stay = false;
        }

        // Update is called once per frame
        void Update()
        {

            float dist = Vector3.Distance(this.transform.position, chamereon.transform.position);
            if (dist > 5.0f&&_stay)
            {
                this.GetComponent<CircleCollider2D>().enabled = true;
            }
            else if(dist < 5 && !_stay)
            {
                this.GetComponent<CircleCollider2D>().enabled = false;
                _stay = true;
            }
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _stay = false;
                chamereon.transform.position = _backPos;
                spawnPosObj.GetComponent<BoxCollider2D>().enabled = false;
                
                StartCoroutine(housemanager.BackEnterHousePoslater());
            }
        }


    }
    

}
    

