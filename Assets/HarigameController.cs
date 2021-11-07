using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HarigameController : MonoBehaviour
{
    public Fungus.Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HarigameClear()
    {
        //SceneManager.LoadScene("WesternScene1.2");
        //SceneManager.UnloadScene("Daiku");
        SceneManager.UnloadSceneAsync("Daiku");
        
    }
}
