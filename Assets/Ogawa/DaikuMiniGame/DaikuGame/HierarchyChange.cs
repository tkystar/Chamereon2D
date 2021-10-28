using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyChange : MonoBehaviour
{
    public GameObject pin1;
    public GameObject pin2;
    public GameObject pin3;
    public GameObject pin4;
    public GameObject pin5;
    public GameObject pin6;

    public struct UIOrder
    {
        public Vector3 trans;
        public int pin;
    }

    private List<UIOrder> UIO = new List<UIOrder>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hierarchy()
    {
        UIO.Add(new UIOrder { trans = pin1.transform.position, pin = 1 });
        UIO.Add(new UIOrder { trans = pin2.transform.position, pin = 2 });
        UIO.Add(new UIOrder { trans = pin3.transform.position, pin = 3 });
        UIO.Add(new UIOrder { trans = pin4.transform.position, pin = 4 });
        UIO.Add(new UIOrder { trans = pin5.transform.position, pin = 5 });
        UIO.Add(new UIOrder { trans = pin6.transform.position, pin = 6 });
        UIO.Sort();
        for (int i = 0; i <= 5;i++)
        {
            Debug.Log(UIO[i]);
        }
    }
}
