using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public GameObject cube;
    public Color startColor;
    public Color endColor;
    public float time;
    [Range(0f, 1f)]
    public float t;
    float Timer;
    MeshRenderer cubeMeshRenderer;

    
    private Text timerText;
    public GameObject TextObj;
    // Start is called before the first frame update
    void Start()
    {
        cubeMeshRenderer = cube.GetComponent<MeshRenderer>();
        cubeMeshRenderer.material.color = endColor;

        timerText = TextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        Debug.Log(Timer);
        if (Input.GetKey("space"))
        {
            //cubeMeshRenderer.material.color = (Color.Lerp(startColor, endColor, /time));
        }
        cubeMeshRenderer.material.color = (Color.Lerp(startColor, endColor, Timer / 10));
    }
}
