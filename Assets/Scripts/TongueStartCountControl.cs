using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TongueStartCountControl : MonoBehaviour
{
    public GameObject BugGenerator;//buggeneratorスクリプトが入っているオブジェクト
    public Text _startcount;//StartCountdownオブジェクト
    float counttime;
    buggenerator b_generator;
    // Start is called before the first frame update
    void Start()
    {
        b_generator = BugGenerator.GetComponent<buggenerator>();
        b_generator.enabled = false;
        counttime = 5.0f;
        StartCoroutine("CountDownCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        //CountTime();
    }

    void CountTime()
    {
        _startcount.gameObject.SetActive(true);
        _startcount.text = "Wait";
        counttime -= Time.deltaTime;
        if (counttime <= 3.0f) _startcount.text = "3";
        if (counttime <= 2.0f) _startcount.text = "2";
        if (counttime <= 1.0f) _startcount.text = "1";
        if (counttime <= 0.0f) _startcount.text = "Start!";
        if (counttime < -1.0f)
        {
            _startcount.gameObject.SetActive(false);

            b_generator.enabled = true;
        }
    }
    IEnumerator CountDownCoroutine()
    {
        _startcount.gameObject.SetActive(true);

        _startcount.text = "Wait";
        yield return new WaitForSeconds(1.0f);

        _startcount.text = "3";
        yield return new WaitForSeconds(1.0f);

        _startcount.text = "2";
        yield return new WaitForSeconds(1.0f);

        _startcount.text = "1";
        yield return new WaitForSeconds(1.0f);

        _startcount.text = "Start!";
        yield return new WaitForSeconds(1.0f);

        _startcount.gameObject.SetActive(false);

        b_generator.enabled = true;
    }
}
