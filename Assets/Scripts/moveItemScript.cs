using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveItemScript : MonoBehaviour
{
    public GameObject player;
    public GameObject item;

    LayerMask mask;
    GameObject item1;
    RaycastHit hit;

    CubeScript2 sc_item1;


    // Start is called before the first frame update
    void Start()
    {
        item1 = Instantiate(item, transform.position, transform.rotation);
        sc_item1 = item1.GetComponent<CubeScript2>();

        mask = ~(1 << 8 | 1 << 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(player.transform.position, player.transform.transform.forward, out hit, Mathf.Infinity, mask))
        {
            sc_item1.ray = true;

            Debug.DrawRay(player.transform.position, player.transform.transform.forward * hit.distance, Color.yellow);

            item1.transform.position = hit.point; // Cubeをレイの当たったところに移動
            item1.transform.rotation = Quaternion.FromToRotation(item.transform.up, hit.normal); // Cubeの上方向をレイが当たったところの表面の方向にする
            item1.transform.position += item1.transform.localScale.y / 1.98f * hit.normal; // Cubeが埋まらないように、表面方向に少し動かす
        }
        else
        {
            sc_item1.ray = false;

        }

    }

}