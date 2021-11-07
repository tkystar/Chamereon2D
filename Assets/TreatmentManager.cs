using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Cinemachine
{


    public class TreatmentManager : MonoBehaviour
    {
        public GameObject treatmentCanvas;
        public GameObject generalCanvas;
        public Button hariMiniGameFinBtn;
        public Fungus.Flowchart flowchart;
        private DaikuTalkController _daikuTalkController;
        private Vector3 minigamePos;
        public CinemachineConfiner2D _cinemachineConfiner2D;
        private GameObject Chamereon;
        public GameObject maincam;
        public GameObject subcam;
        // Start is called before the first frame update
        void Start()
        {
            Chamereon = GameObject.Find("Camereon");
            treatmentCanvas.SetActive(false);
            hariMiniGameFinBtn.onClick.AddListener(Treatmentfin);
            _daikuTalkController = GameObject.Find("Daiku").GetComponent<DaikuTalkController>();
            minigamePos = new Vector3(-28, 0, 0);
            _cinemachineConfiner2D = GameObject.Find("CM vcam2").GetComponent<CinemachineConfiner2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Treatment()
        {
            _cinemachineConfiner2D.enabled = false;
            flowchart.SetBooleanVariable("getSaboten", false);
            flowchart.SetBooleanVariable("DaikuTalkPossibility", false);
            treatmentCanvas.SetActive(true);
           // generalCanvas.SetActive(false);
           // _daikuTalkController.detectionTrigger = false;
            Chamereon.transform.position = new Vector3(0,0,0);
            Chamereon.GetComponent<SpriteRenderer>().enabled = false;
        }

        public void TreatmentminigameStart()
        {
            //SceneManager.LoadScene("Daiku");
            SceneManager.LoadScene("Daiku", LoadSceneMode.Additive);
        }

        public void Treatmentfin()
        {
            Chamereon.GetComponent<SpriteRenderer>().enabled = true;
            flowchart.SetBooleanVariable("DaikuTalkPossibility", true);
            flowchart.SetBooleanVariable("DaikuisReady", true);
            treatmentCanvas.SetActive(false);
            generalCanvas.SetActive(true);
            Chamereon.transform.position = new Vector3(166, -74, 0);
            //_daikuTalkController.detectionTrigger = true;

        }

        public void aa()
        {
            maincam.SetActive(false);
            subcam.SetActive(true);
        }
    }

}