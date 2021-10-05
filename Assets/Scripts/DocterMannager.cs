using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocterMannager : MonoBehaviour
{
    private GameObject _chamereon;
    private float _distance;
    private Vector3 _posChamereon;
    private Vector3 _posDocter;
    [SerializeField] private float DISTANCE;
    private bool _docterDetection;
    public Fungus.Flowchart flowchart;
    private DaikuTalkController _daikuTalkController;
    public bool docterTalkFin=false;
    // Start is called before the first frame update
    void Start()
    {
        _chamereon = GameObject.Find("Camereon");
        _daikuTalkController = GameObject.Find("Daiku").GetComponent<DaikuTalkController>();
        _docterDetection = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        _posChamereon = _chamereon.transform.position;
        _posDocter = this.gameObject.transform.position;
        _distance = Vector3.Distance(_posChamereon, _posDocter);
        
        if(_docterDetection)
        {
            if (_distance < DISTANCE)
            {
                talkDocter();
            }
        }
        


    }


    private void talkDocter()
    {
        if(_daikuTalkController.talkcounter== "firstfin")
        {
            flowchart.ExecuteBlock("Doctor_Waist");
            flowchart.SetBooleanVariable("docterfin", true);
        }
        else
        {
            flowchart.ExecuteBlock("Doctor_justtalk");
        }
        
    }

    private void talkfin()
    {
        StartCoroutine("talkfinCor");
    }

    private IEnumerator talkfinCor()
    {
        docterTalkFin = true;
        _docterDetection = false;
        yield return new WaitForSeconds(3.0f);
        _docterDetection = true;

    }
}
