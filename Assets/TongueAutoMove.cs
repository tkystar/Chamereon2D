using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAutoMove : MonoBehaviour
{
    private Vector3 xn;
    private bool push;
    public GameObject Tonguehead;
    public GameObject headimage;//カメレオン頭の画像
    [SerializeField]
    private float speed;//舌のスピード
    Animator animator;//口の開閉アニメーション
    BoxCollider tongue_collider;//tongueheadのコライダー
    // Start is called before the first frame update
    void Start()
    {
        
        xn = transform.localPosition;//ローカル座標の取得
        xn.x = -7.5f;
        transform.localPosition = xn;
        //speed = 0.03f;
        push = false;
        tongue_collider = Tonguehead.GetComponent<BoxCollider>();
        tongue_collider.enabled = false;
        animator = headimage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("AfterPushDown");
                       
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
}
