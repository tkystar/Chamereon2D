using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera wolfCam;
    // Start is called before the first frame update
    void Start()
    {
        wolfCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchwolfCam()
    {
        wolfCam.enabled = true;
        mainCam.enabled = false;
    }

    public void switchDefCam()
    {
        wolfCam.enabled = false;
        mainCam.enabled = true;
    }
}
