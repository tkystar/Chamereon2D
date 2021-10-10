using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    private bool _bridgeDetection;
    private float _distance;
    [SerializeField]private float DISTANCE;
    private GameObject _chamereon;
    private Vector3 _posChamereon;
    private Vector3 _posRiverCollider;
    public Fungus.Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        _chamereon=GameObject.Find("Camereon");
    }

    // Update is called once per frame
    void Update()
    {

        _posChamereon = _chamereon.transform.position;
        _posRiverCollider = this.gameObject.transform.position;
        _distance = Vector3.Distance(_posChamereon, _posRiverCollider);

        if(_bridgeDetection)
        {
            if (_distance < DISTANCE)
            {
                ArriveRiver();
            }
        }
        
    }

    void ArriveRiver()
    {
        flowchart.ExecuteBlock("River");
        
    }
}
