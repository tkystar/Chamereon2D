using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAutoMove : MonoBehaviour
{
    private Vector3 xn;
    private bool push;
    private int g_update_point;//目標達成後の次の目標値
    public static int dificulty;//ゲームの難易度
    public GameObject Tonguehead;
    public GameObject BugGenerator;
    public GameObject headimage;//カメレオン頭の画像
    [Header("舌のスピード")]
    public float speed;//舌のスピード
    Animator animator;//口の開閉アニメーション
    BoxCollider tongue_collider;//tongueheadのコライダー
    buggenerator b_generator;
    // Start is called before the first frame update
    void Start()
    {
        
        xn = transform.localPosition;//ローカル座標の取得
        xn.x = -7.5f;
        transform.localPosition = xn;
        push = false;
        tongue_collider = Tonguehead.GetComponent<BoxCollider>();
        tongue_collider.enabled = false;
        animator = headimage.GetComponent<Animator>();
        b_generator = BugGenerator.GetComponent<buggenerator>();
        dificulty = 1;
        g_update_point = 100;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("AfterPushDown");
        if (b_generator.g_point< buggenerator.b_sum)
        {
            //dificulty += 1; 
            SpeedUp();
        }
                       
    }

    public void PushDown()
    {
        animator.SetBool("open", true);
        animator.SetBool("close", false);
        push = true;
        tongue_collider.enabled = true;
    }

    public IEnumerator AfterPushDown()
    {
        if (push)
        {
            yield return new WaitForSeconds(0.3f);
            xn.x += speed;
            if (xn.x > 8f)
            {
                xn.x = 8f;
            }
        }
        else
        {
            xn.x -= speed;
            if (xn.x < -7.5f)
            {
                xn.x = -7.5f;
                tongue_collider.enabled = false;
                animator.SetBool("close", true);

            }
        }
        transform.localPosition = xn;
        yield break;
    }

    public void PushUp()
    {
        push = false;
        animator.SetBool("open", false);
    }

    void SpeedUp()//舌のスピードアップ＆目標値変更
    {
        speed += 0.1f;

        switch (dificulty)
        {
            case 2:
                g_update_point = 200;
                break;
            case 3:
                g_update_point = 300;
                break;
            case 4:
                g_update_point = 400;
                break;
        }
        b_generator.g_point = g_update_point;
        buggenerator.goal_point.text = "目標 : "+ b_generator.g_point.ToString();
    }
}
