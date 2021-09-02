using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAutoMove : MonoBehaviour
{
    private Vector3 xn;//舌の位置
    private Vector3 l_xn;//LockOnRootの位置
    private bool push;
    public static bool drag_switch;//dragの開始位置が特定の範囲のときtrueになる
    private int g_update_point;//目標達成後の次の目標値
    public static int dificulty;//ゲームの難易度
    public GameObject Tonguehead;
    public GameObject BugGenerator;
    public GameObject headimage;//カメレオン頭の画像
    public GameObject DragRabge;
    public Transform LockOnRoot;//照準オブジェクト（lockon）の親オブジェクト
    private SpriteRenderer lockonrend;//照準オブジェクト（lockon）のSpriteRenderer
  
    [Header("舌のスピード")]
    public float speed;//舌のスピード
    Animator animator;//口の開閉アニメーション
    BoxCollider tongue_collider;//tongueheadのコライダー
    buggenerator b_generator;

    Vector2 baseposition;//タッチ直後の指の初期位置
    Vector2 currentposition;//タッチし続けているときの指の位置
    float distance;//baseposition-currentposition
    float maxdistance;//distanceの最大値
    float maxtonguelength;//舌の長さの最大値
    // Start is called before the first frame update
    void Start()
    {
       
        lockonrend = LockOnRoot.Find("lockon").GetComponent<SpriteRenderer>();
        lockonrend.material.color = new Color32(255, 255, 255, 0);
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
        maxdistance = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("AfterPushDown");
        ScreenTouch_TongueMove();
        MouseTouch_TongueMove();
        //StartCoroutine("TongueAction");
        if (push)
        {
            //yield return new WaitForSeconds(0.25f);
            lockonrend.material.color = new Color32(255, 255, 255, 0);
            xn.x += speed;
            transform.localPosition = xn;
            if (xn.x >= maxtonguelength)
            {
                push = false;
                drag_switch = false;
            }
        }
        if (!push)
        {
            animator.SetBool("open", false);
            xn.x -= speed;
            if (xn.x < -7.5f)
            {
                xn.x = -7.5f;
                tongue_collider.enabled = false;
                transform.localPosition = xn;
                animator.SetBool("close", true);
                //animator.SetBool("close", false);
            }
            transform.localPosition = xn;
        }
        if (b_generator.g_point < buggenerator.b_sum)
        {

            //SpeedUo();
        }
        if (b_generator.countTime < 0) tongue_collider.enabled = false;//制限時間を超えたら舌のコライダーを無効にする
    }


    public void PushDown()//ボタン押下直後
    {
        animator.SetBool("open", true);
        animator.SetBool("close", false);
        push = true;
        tongue_collider.enabled = true;
    }
    public void PushUp()//ボタン離す直後
    {
        push = false;
        animator.SetBool("open", false);
    }

    /*public IEnumerator AfterPushDown()//ボタン操作における舌の移動処理
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
    }*/

    /*public IEnumerator TongueAction()
    {
        if (push)
        {
            //yield return new WaitForSeconds(0.25f);
            lockonrend.material.color = new Color32(255, 255, 255, 0);
            xn.x += speed;
            transform.localPosition = xn;
            if (xn.x >= maxtonguelength) push = false;
        }
        if (!push)
        {
            animator.SetBool("open", false);
            xn.x -= speed;
            if (xn.x < -7.5f)
            {
                xn.x = -7.5f;
                tongue_collider.enabled = false;
                animator.SetBool("close", true);
                transform.localPosition = xn;
                //animator.SetBool("close", false);
            }
            transform.localPosition = xn;
        }    
        yield break;
    }*/
    /*
     public IEnumerator TongueAction()//AfterpushDownと併用
    {
        if (push)
        {
            yield return new WaitForSeconds(0.3f);
            xn.x += speed;
            
        }
        if (xn.x >= maxtonguelength)
        {
            push = false;
            animator.SetBool("open", false);
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
     */
    public void DragSwitch()
    {
        if(b_generator.countTime >0) drag_switch = true;
        if (b_generator.countTime < 0) drag_switch = false;//時間が過ぎたらドラッグできないようにする
    }
    void ScreenTouch_TongueMove()
    {
        if(Input.touchCount >0 && drag_switch)
        {
            Touch t1 = Input.touches[0];
            if(t1.phase == TouchPhase.Began)
            {
                baseposition = Camera.main.ScreenToWorldPoint(t1.position);
                LockOnRoot.localPosition = new Vector3(-7.5f, 0, 0);
                lockonrend.material.color = new Color32(255, 255, 255, 255);
            }
            if(t1.phase == TouchPhase.Moved)
            {
                currentposition = Camera.main.ScreenToWorldPoint(t1.position);
                distance = Vector2.Distance(baseposition, currentposition);
                if (distance > maxdistance) distance = maxdistance;
                l_xn.x = (distance / maxdistance * 15.5f) - 7.5f;
                LockOnRoot.localPosition = l_xn;
            }
            if (t1.phase == TouchPhase.Ended)
            {
                animator.SetBool("open", true);
                lockonrend.material.color = new Color32(255, 255, 255, 0);
                distance = Vector2.Distance(baseposition,currentposition);
                if (distance > maxdistance) distance = maxdistance;
                maxtonguelength = (distance / maxdistance * 15.5f)-7.5f;
                push = true;
                tongue_collider.enabled = true;
               
            }
        }
    }

     void MouseTouch_TongueMove()
    {
        if (drag_switch)
        {
            if (Input.GetMouseButtonDown(0))
            {
                baseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(baseposition);
                LockOnRoot.localPosition = new Vector3(-7.5f, 0, 0);
                lockonrend.material.color = new Color32(255, 255, 255, 255);
            }
            if (Input.GetMouseButton(0))
            {
                currentposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                distance = Vector2.Distance(baseposition, currentposition);
                if (distance > maxdistance) distance = maxdistance;
                l_xn.x = (distance / maxdistance * 15.5f) - 7.5f;
                LockOnRoot.localPosition = l_xn;

            }
            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("open", true);
                distance = Vector2.Distance(baseposition, currentposition);
                if (distance > maxdistance) distance = maxdistance;
                maxtonguelength = (distance / maxdistance * 15.5f) - 7.5f;
                push = true;
                tongue_collider.enabled = true;
               
            }
        }
    }

    void SpeedUp()//舌のスピードアップ＆目標値変更
    {
        dificulty += 1;
        speed += 0.03f;

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
