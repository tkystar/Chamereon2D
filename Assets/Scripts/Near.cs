using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine.Utility;

namespace Cinemachine
{
    public class Near : MonoBehaviour
    {
        public Fungus.Flowchart flowchart;

        public GameObject Player;
        Transform Target;
        public GameObject camereon;
        public GameObject UIimage;
        bool once = true;
        bool oncee = true;
        //public GameObject maincamera;
        // Start is called before the first frame update
        void Start()
        {
            Target = Player.transform;

        }

        // Update is called once per frame
        void Update()
        {

            float distance = (Target.position - camereon.transform.position).magnitude;
            //Debug.Log(distance);
            if (distance < 4 && once)
            {

                //UIImageAppear();
                if (oncee)
                {
                    flowchart.ExecuteBlock("1-1");
                    oncee = false;
                    //maincamera.GetComponent<CinemachineBrain>().enabled = false;
                }


            }
            else if (distance > 7)
            {
                once = true;
            }
        }
        void UIImageAppear()
        {
            UIimage.SetActive(true);
            once = false;
        }
    }

}
