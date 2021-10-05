using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotenManager : MonoBehaviour
{
    private Vector3 _posChamereon;
    private Vector3 _posSaboten;
    private GameObject _chamereon;
    private float _distance;
    private bool _sabotenDetection;
    private DocterMannager _docterMannager;
    [SerializeField] private float DISTANCE;
    public Fungus.Flowchart flowchart;
   
    // Start is called before the first frame update
    void Start()
    {
        _chamereon = GameObject.Find("Camereon");
        _docterMannager = GameObject.Find("Doctor").GetComponent<DocterMannager>();
        _sabotenDetection = true;
    }

    // Update is called once per frame
    void Update()
    {
        _posChamereon = _chamereon.transform.position;
        _posSaboten = this.gameObject.transform.position;
        _distance = Vector3.Distance(_posChamereon, _posSaboten);

        if (_sabotenDetection)
        {
            if (_distance < DISTANCE)
            {
                talkSaboten();
            }
        }

    }

    private void talkSaboten()
    {
        flowchart.ExecuteBlock("Saboten");
        

    }

    private void talkfin()
    {
        StartCoroutine("talkfinCor");
    }

    private IEnumerator talkfinCor()
    {
        Debug.Log("sabotenfin");
        flowchart.SetBooleanVariable("getSaboten", true);
        _sabotenDetection = false;
        yield return new WaitForSeconds(3.0f);
        _sabotenDetection = true;

    }
}
