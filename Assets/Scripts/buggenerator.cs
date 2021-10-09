using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buggenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyObj;
    [Header("制限時間表示オブジェクト")]
    public GameObject Timer;
    [Tooltip("制限時間(秒)の数値(float型)")]
    public float countTime;
    [Header("獲得ポイント表示オブジェクト")]
    public GameObject Point;
    [Header("目標のポイント数表示オブジェクト")]
    public GameObject GoalPoint;
    [Tooltip("目標ポイント数(int型)")]
    public  int g_point;//目標のポイント数
    public static Text b_point;
    public static Text goal_point;
    public static Text timekeeper;//countTimeのtext
    public static int b_sum;
    [Header("結果を表示するオブジェクト")]
    public GameObject FinishResult;//結果を表示するオブジェクト(FinishResult)
    // 敵を生成するまでの時間
    float timer;
    // 敵を生成するまでの閾値
    float instantiateInterval;
    // 敵の最大生成数
    int maxInstanceValue;
    // 制限時間を超えたかどうか
    bool countover;
    void Start()
    {
        countover = false;
        timer = 1;
        instantiateInterval = 3;
        maxInstanceValue = 10;
        // プレイヤーオブジェクトを取得

        b_point = Point.GetComponent<Text>();
        goal_point = GoalPoint.GetComponent<Text>();
        goal_point.text = "目標 : " + g_point;
        
        timekeeper = Timer.GetComponent<Text>();
    }
    void Update()
    {
        if (!countover)
        {
            // 敵オブジェクトの生成関数を呼び出す
            GenerateEnemy();
            countTime -= Time.deltaTime;
            if (countTime < 0) countover = true;
            timekeeper.text = countTime.ToString("F2");
        }
        if (countover)
        {
            timekeeper.text = "";
            FinishResult.SetActive(true);
        }
    }
    // 敵オブジェクトの生成関数
    void GenerateEnemy()
    {
        // カウンタ
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (maxInstanceValue > 0)
            {
                // プレイヤーからx軸方向に10、y軸方向に1移動した位置に
                // 敵を出現させる
                Instantiate(enemyObj,
                  new Vector3(30,Random.Range(1,8),-12), transform.rotation);
                // 最大出現数を減らす
                //maxInstanceValue--;
                // タイマーのリセット
                timer = 3;
            }
        }
    }

}
