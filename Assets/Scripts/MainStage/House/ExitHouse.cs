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
        HouseManager _houseManager;
        bool _stay;

        

        // Start is called before the first frame update
        void Start()
        {
            _backPos = spawnPosObj.GetComponent<Transform>().position;
            this.GetComponent<BoxCollider2D>().enabled = false;
            _stay = false;
            _houseManager = spawnPosObj.GetComponent<HouseManager>();
            
        }

        // Update is called once per frame
        void Update()
        {

            float dist = Vector3.Distance(this.transform.position, chamereon.transform.position);
            if (dist > 5.0f&&_stay)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if(dist < 5 && !_stay)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                _stay = true;
            }

            
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine("Exit");

            }
        }

        public IEnumerator Exit()
        {
            
            _houseManager.fadeOut();
            yield return new WaitForSeconds(1.0f);
            _houseManager.down = true;
            _houseManager.fadeIn();
            _stay = false;
            chamereon.transform.position = _backPos;
            _houseManager._cinemachineConfiner2D.enabled=true;
            spawnPosObj.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(_houseManager.BackEnterHousePoslater());
            yield return new WaitForSeconds(1.0f);
            _houseManager.down = false;

        }

        

        

    }
    

}
    

