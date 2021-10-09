using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentManager : MonoBehaviour
{
    public GameObject treatmentCanvas;
    public GameObject generalCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        treatmentCanvas.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Treatment()
    {

        treatmentCanvas.SetActive(true);
        generalCanvas.SetActive(false);
    }
}
