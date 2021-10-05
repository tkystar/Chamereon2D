using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject Player;
    Transform Target;
    public GameObject camereon;
    public GameObject UIimage;
    bool once = true;
    protected static int Score = 0;

    void Start()
    {
        Target = Player.transform;
    }

    void Update()
    {
        float distance = (Target.position - camereon.transform.position).magnitude;
        //Debug.Log(distance);
        if (distance < 7 && once)
        {
            ChangeScene();



        }
        else if (distance > 7)
        {
            once = true;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("NvigationTileMap");
    }

    public static int GetScore()
    {
        return Score;
    }

}