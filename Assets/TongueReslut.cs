using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TongueReslut : MonoBehaviour
{
    public Text _tongueresult;
    [SerializeField]
    private GameObject BugGenerator;
    
    buggenerator b_generator;
    // Start is called before the first frame update
    void Start()
    {
        _tongueresult.gameObject.SetActive(true);
        b_generator = BugGenerator.GetComponent<buggenerator>();
        Result();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Result()
    {
        if(buggenerator.b_sum >= b_generator.g_point)
        {
            _tongueresult.text = "SUCCESS";
        }
        if(buggenerator.b_sum < b_generator.g_point)
        {
            _tongueresult.text = "FAILURE";
        }
    }
}
