using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BridgeController : MonoBehaviour
{
    public Button finBtn;
    public GameObject wolf;
    WolfAnimationController wolfAnimationController;
    CameraManager CameraManager;
    
    // Start is called before the first frame update
    void Start()
    {
        finBtn.onClick.AddListener(bridgeFin);
        wolfAnimationController = wolf.GetComponent<WolfAnimationController>();
        CameraManager = this.GetComponent<CameraManager>();
        
    }
    // Update is called once per frame


    void Update()
    {
        
    }

    public void bridgeFin()
    {
        wolfAnimationController.escape();
    }

    public void bridgeMiniGameStart()
    {
        SceneManager.LoadScene("MiniGame");
    }

}
