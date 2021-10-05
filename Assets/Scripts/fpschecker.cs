using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpschecker : MonoBehaviour
{
    public GameObject FPScheck;
    Text fpscheck;
    int frameCount;// Update()が呼ばれた回数をカウントします。
    float elapsedTime;// 前回フレームレートを表示してからの経過時間です。
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;//フレームレイトの設定
        fpscheck = FPScheck.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 呼ばれた回数を加算します。
        frameCount++;
        // 前のフレームからの経過時間を加算します。
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1.0f)
        {
            // 経過時間が1秒を超えていたら、フレームレートを計算します。
            float fps = 1.0f * frameCount / elapsedTime;

            // 計算したフレームレートを画面に表示します。(小数点以下2ケタまで)
            string fpsRate = $"FPS: {fps.ToString("F2")}";
            fpscheck.text = fpsRate;

            // フレームのカウントと経過時間を初期化します。
            frameCount = 0;
            elapsedTime = 0f;
        }
    }
}
