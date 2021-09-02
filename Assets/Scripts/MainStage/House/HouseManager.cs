using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Western
{

    public class HouseManager : MonoBehaviour
    {

        public GameObject Chamereon;
        Vector3 SpawnPos;
        public GameObject spawnPosObject;
        public GameObject ExitPosObject;

        public bool _stay;
        // Start is called before the first frame update
        void Start()
        {
            SpawnPos = spawnPosObject.GetComponent<Transform>().position;
            _stay = false;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

        // Update is called once per frame
        void Update()
        {


            if (_stay)
            {
                float dist = Vector3.Distance(SpawnPos, Chamereon.transform.position);

                if (dist > 10.0f)
                {
                    this.GetComponent<BoxCollider2D>().enabled = true;
                }

            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

            if (collision.gameObject.tag == ("Player"))
            {
                Chamereon.transform.position = SpawnPos;
                _stay = false;
            }
        }



        public IEnumerator BackEnterHousePoslater()
        {
            yield return new WaitForSeconds(1.0f);
            _stay = true;
        }
    }
}
