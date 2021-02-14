using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript2 : MonoBehaviour
{
    /// <summary>
    /// 射出するオブジェクト
    /// </summary>
    [SerializeField, Tooltip("射出するオブジェクトをここに割り当てる")]
    private GameObject ThrowingObject;
    private Rigidbody rb;
    public GameObject zentai;
    /// <summary>
    /// 標的のオブジェクト
    /// </summary>
    [SerializeField, Tooltip("標的のオブジェクトをここに割り当てる")]
    private GameObject[] TargetObject;
    
    /// <summary>
    /// 射出角度
    /// </summary>
    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float ThrowingAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            // 干渉しないようにisTriggerをつける
            collider.isTrigger = true;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // spaceでボールを射出する
            ThrowingBall();
            Destroy(this.gameObject);
           // Destroy(TargetObject[0]);
        }
        float distance1 = Vector3.Distance(transform.position, TargetObject[0].transform.position);
        float distance2 = Vector3.Distance(transform.position, TargetObject[1].transform.position);
        // Debug.Log(distance);
        if (distance1 < 1|| distance2 <1)
        {
            rb.isKinematic = true;
            //rb.velocity = Vector3.zero;
        }

    }

    /// <summary>
    /// ボールを射出する
    /// </summary>
    public void ThrowingBall()
    {
        if (ThrowingObject != null && TargetObject != null)
        {
            // Ballオブジェクトの生成
            GameObject ball = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

            // 標的の座標
            Vector3 righttargetPosition = TargetObject[0].transform.position;
            Vector3 lefttargetPosition = TargetObject[1].transform.position;

            // 射出角度
            float angle = ThrowingAngle;

            // 射出速度を算出
            Vector3 rightvelocity = CalculateVelocity(this.transform.position, righttargetPosition, angle);
            Vector3 leftvelocity = CalculateVelocity(this.transform.position, lefttargetPosition, angle);
            // 射出
            Rigidbody rid = ball.GetComponent<Rigidbody>();

            Rigidbody rbRight=TargetObject[0].gameObject.GetComponent<Rigidbody>();
            Rigidbody rbLeft = TargetObject[1].gameObject.GetComponent<Rigidbody>();

            if (rbRight.isKinematic) {
                rid.AddForce(rightvelocity * rid.mass, ForceMode.Impulse);
            }
            if (rbLeft.isKinematic) {
                rid.AddForce(leftvelocity * rid.mass, ForceMode.Impulse);
            }
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }

       
    }

    /// <summary>
    /// 標的に命中する射出速度の計算
    /// </summary>
    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    /// <returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
    void OnCollisionEnter(Collision col)
    {

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }

}