using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Western
{

    public class ExitHouse : MonoBehaviour
    {
        public GameObject chamereon;
        public GameObject spawnPosObj;
        Vector3 _backPos;
        HouseManager housemanager;
        // Start is called before the first frame update
        void Start()
        {
            _backPos = spawnPosObj.GetComponent<Transform>().position;
            this.GetComponent<CircleCollider2D>().enabled = false;
            housemanager=spawnPosObj.GetComponent<HouseManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                chamereon.transform.position = _backPos;
                spawnPosObj.GetComponent<BoxCollider2D>().enabled = false;
                housemanager.BackEnterHousePos();
            }
        }


    }
    

}
    

