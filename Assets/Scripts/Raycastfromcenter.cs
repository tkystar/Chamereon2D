using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastfromcenter : MonoBehaviour
{
    
    //public GameObject obj;
    public GameObject ika;
    bool jump = false;
    bool grab = false;
    // Start is called before the first frame update


    [SerializeField, Tooltip("射出するオブジェクトをここに割り当てる")]
    //private GameObject ThrowingObject;
    private Rigidbody rb;
    //public GameObject zentai;
    /// <summary>
    /// 標的のオブジェクト
    /// </summary>
    
    /// <summary>
    /// 射出角度
    /// </summary>
    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float ThrowingAngle;



    void Start()
    {
        ika.gameObject.GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();
        Collider collider = GetComponent<Collider>();
        
    }

    public void jumpBtnClick()
    {
        jump =false;
        grab = false;
        rb.isKinematic=false;
    }
    public void jumpBtnUp()
    {
        jump = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jump == true) { 
          Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
          var ray = Camera.main.ScreenPointToRay(center);
          RaycastHit hit;
          //if (Physics.Raycast(arcamera.transform.position, transform.TransformDirection(Vector3.forward), out hit))
           if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Player"))
          {

            Debug.Log(hit.point);

            //Instantiate(obj, hit.point, Quaternion.identity);

            ThrowingBall(hit.point);
            grab = true;
            //Destroy(this.gameObject);
          }
            float distance = Vector3.Distance(transform.position, hit.point);
            // Debug.Log(distance);
            if (distance < 1)
            {
                rb.isKinematic = true;
                //rb.velocity = Vector3.zero;
               
            }
            jump = false;
            
        }


        

    }
    public void ThrowingBall(Vector3 point)
    {
       
            // Ballオブジェクトの生成
            //GameObject ball = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

            // 標的の座標
            //Vector3 righttargetPosition = TargetObject[0].transform.position;
            //Vector3 lefttargetPosition = TargetObject[1].transform.position;

            // 射出角度
            float angle = ThrowingAngle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, point, angle);
            
            // 射出
            Rigidbody rid = ika.gameObject.GetComponent<Rigidbody>();

            
            
                rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
            
            
        
       


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
    /*
    void OnCollisionEnter(Collision col)
    {

        Rigidbody rb =gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        Debug.Log("A");

    }*/
}
