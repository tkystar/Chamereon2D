using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript2 : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color defaultColor;
    Color defaultColor_Transparent;

    public bool ray = false;
    bool trigStay = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultColor = meshRenderer.material.GetColor("_BaseColor");
        defaultColor_Transparent = defaultColor;
        defaultColor_Transparent.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trigStay && ray)
        {
            meshRenderer.material.SetColor("_BaseColor", defaultColor);
        }
        else
        {
            meshRenderer.material.SetColor("_BaseColor", Color.red);
            //meshRenderer.material.SetColor("_BaseColor", defaultColor_Transparent);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        trigStay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigStay = false;
    }
}