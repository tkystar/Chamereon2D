
namespace Western
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class AreaExit : MonoBehaviour
    {
       
        public GameObject Player;
        Transform Target;
        public GameObject camereon;
       // public GameObject UIimage;
        bool once = true;
        bool oncee = true;
        Scene WesternScene;
        // Start is called before the first frame update
        void Start()
        {
            Target = Player.transform;
        }
        // Update is called once per frame
        private void Update()
        {
            float distance = (Target.position - camereon.transform.position).magnitude;
            //Debug.Log(distance);
            if (distance < 4 && once)
            {

                
                    SceneManager.LoadScene("WesternScene1.2");
                 


            }
        }

        
    }
}