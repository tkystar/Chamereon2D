using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreatmentManager : MonoBehaviour
{
    public GameObject treatmentCanvas;
    public GameObject generalCanvas;
    public Button hariMiniGameFinBtn;
    public Fungus.Flowchart flowchart;
    private DaikuTalkController _daikuTalkController;
    // Start is called before the first frame update
    void Start()
    {
        treatmentCanvas.SetActive(false);
       hariMiniGameFinBtn.onClick.AddListener(Treatmentfin);
       _daikuTalkController=GameObject.Find("Daiku").GetComponent<DaikuTalkController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Treatment()
    {
        flowchart.SetBooleanVariable("getSaboten", false);
        flowchart.SetBooleanVariable("DaikuTalkPossibility", false);
        treatmentCanvas.SetActive(true);
        generalCanvas.SetActive(false);
        _daikuTalkController.detectionTrigger=false;
    }

    private void Treatmentfin()
    {
        flowchart.SetBooleanVariable("DaikuTalkPossibility", true);
        flowchart.SetBooleanVariable("DaikuisReady", true);
        treatmentCanvas.SetActive(false);
        generalCanvas.SetActive(true);
        _daikuTalkController.detectionTrigger=true;
        
    }
}
