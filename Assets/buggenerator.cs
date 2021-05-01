using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buggenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyObj;
    public float countTime;
    public GameObject Point;
    public GameObject GoalPoint;
    public GameObject Timer;
    public static Text b_point;
    public static Text goal_point;
    public static Text timekeeper;
    public int g_point;
    public static int b_sum;
    
    // 敵を生成するまでの時間
    float timer;
    // 敵を生成するまでの閾値
    float instantiateInterval;
    // 敵の最大生成数
    int maxInstanceValue;
    void Start()
    {
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
        // 敵オブジェクトの生成関数を呼び出す
        GenerateEnemy();

        countTime -= Time.deltaTime;
        timekeeper.text = countTime.ToString("F2"); 
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
                  new Vector3(-10,Random.Range(4,6),-9), transform.rotation);
                // 最大出現数を減らす
                //maxInstanceValue--;
                // タイマーのリセット
                timer = 3;
            }
        }
    }

}
