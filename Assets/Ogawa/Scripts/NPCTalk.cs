using System.Collections;
using UnityEngine;
using Fungus;
[RequireComponent(typeof(Flowchart))]
public class NPCTalk : MonoBehaviour
{
    [SerializeField]
    string message = "";
    bool isTalking = false;
    GameObject playerObj;
    JustMove player;
    Flowchart flowChart;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<JustMove>();
        flowChart = GetComponent<Flowchart>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Talk());
        }
    }
    IEnumerator Talk()
    {
        if (isTalking)
        {
            yield break;
        }
        isTalking = true;
        flowChart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);
        isTalking = false;
    }
}