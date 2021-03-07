
namespace Camereon2D
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class RandomItem : MonoBehaviour
    {
        public GameObject[] Items;
        private TimeController timecontroller;
        //private Detection detection;
        //public GameObject player;
        public float timeOut;
        private float timeElapsed;
        // Start is called before the first frame update
        void Start()
        {
            //detection = player.GetComponent<detection>();
        }

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;

            int x = Random.Range(-84, 69);
            int y = Random.Range(-37, 46);
            int number = Random.Range(0, Items.Length);

            if (timeElapsed >= timeOut)
            {

                Instantiate(Items[number], new Vector2(x, y), Quaternion.identity);

                timeElapsed = 0.0f;
                Debug.Log("D");
            }
            


        }
    }
}
