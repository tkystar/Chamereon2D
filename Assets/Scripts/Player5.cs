using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CharacterControllerを追加する
[RequireComponent(typeof(CharacterController))]
public class Player5 : MonoBehaviour
{

    //移動速さ、落ちる速さ、ジャンプする速さ
    public float speed = 3f;
    public float gravity = 10f;
    public float jumpSpeed = 5f;

    //Playerの移動や向く方向を入れる
    Vector3 moveDirection;

    //CharacterControllerを変数にする
    CharacterController controller;

    //マウスの横縦に動かす速さ
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    //Main Cameraを入れる
    GameObject came;

    //Raycastが反応した時Trueになる
    [SerializeField]
    bool rayUp, rayDown, rayHead, rayBack;
    //面移動を管理する
    [SerializeField]
    bool upMode, downMode, downUpMode, sideMoveMode, separateMode = false;
    //upModeは壁から上の面へ
    //downModeは壁から底の面へ
    //downUpModeは底の面から壁へ
    //sideMoveModeは壁から壁へ
    //separateModeは壁や底から離れる時に

    void Start()
    {

        //CharacterControllerを取得
        controller = GetComponent<CharacterController>();

        //Main Cameraを検索し子オブジェクトにしてPlayerに設置する
        came = GameObject.Find("Main Camera");
        came.transform.parent = this.transform;
        came.transform.localPosition = new Vector3(0, 0.4f, 0);

    }

    void Update()
    {
        //Playerが地面に設置していることを判定
        if (controller.isGrounded)
        {
            upMode = false;
            rayBack = true;
            separateMode = true;

            //マウスでカメラの向きとPlayerの横の向きを変える
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0, h, 0);
            came.transform.Rotate(v, 0, 0);

            //XZ軸の移動と向きを代入する
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
                                    Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Y軸方向にジャンプさせる
            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;
        }

        // Move関数に代入する
        controller.Move(moveDirection * Time.deltaTime);

        //Raycastが当たったらbool変数をTrueにする
        //正面へ出ているRaycast、壁に張り付くため
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,
            out hit, 2f)
            //separateModeをオフにすると反応せず壁から落ちることができるようになる
            && separateMode)
            rayDown = true;
        else rayDown = false;

        //正面の少し高いところから出ているRaycast、上の面に出るときや底に潜る時に利用
        RaycastHit hit2;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.2f,
                    transform.position.z), new Vector3(transform.forward.x,
                    transform.forward.y + 0.2f,
                    transform.forward.z),
                    out hit2, 2f) && separateMode)
            rayUp = true;
        else rayUp = false;

        //上に向けて出ているRaycast、底に張り付くため
        RaycastHit hit3;
        if (Physics.Raycast(transform.position, transform.up,
            out hit3, 3f) && separateMode)
            rayHead = true;
        else rayHead = false;

        //後ろへ出ているRaycast、壁に振り向くため
        RaycastHit hit4;
        if (Physics.Raycast(transform.position, transform.forward * -1,
            out hit4, 2f))
            rayBack = true;
        else rayBack = false;

        //壁に張り付く
        if (rayDown && rayUp)
        {
            upMode = true;
            downMode = true;
            sideMoveMode = true;

            //ここでは前後移動が上下移動になる
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"), 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            //ここでもマウスでカメラを動かすが、横に動かしてもPlayerの向きは変わらない
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            came.transform.Rotate(0, h, 0);
            came.transform.Rotate(v, 0, 0);

            //スペースキーで壁を離れる
            if (separateMode && Input.GetKeyDown(KeyCode.Space))
            {
                separateMode = false;
                came.transform.rotation =
                Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 10);
            }

        }
        else
        //底での操作
        if (rayHead)
        {
            downUpMode = true;

            //マウスでカメラの向きとPlayerの横の向きを変える
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0, h, 0);
            came.transform.Rotate(v, 0, 0);

            //XZ軸の移動と向きを代入する
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
                                    Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            //スペースキーで底から離れて落ちる
            if (separateMode && Input.GetButtonDown("Jump"))
                separateMode = false;
        }
        //再びスペースキーを押すと壁に張り付けるように
        else if (!separateMode && Input.GetKeyDown(KeyCode.Space))
            separateMode = true;
        //面に張り付いていない時は重力が働く
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //上の面に上がる時
        //正面から出ている2つのRayの上の方が当たらなくなったら発動
        if (rayDown && !rayUp && upMode)
        {
            transform.position = transform.position + transform.forward * 1.5f + transform.up * 2;

            //カメラが正面を向く
            came.transform.rotation =
                Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 360);

            upMode = false;
        }

        //壁から底に潜る時
        //正面から出ている2つのRayの下の方が当たらなくなったら発動
        if (!rayDown && rayUp && downMode)
        {
            transform.position = transform.position + transform.forward * 3f - transform.up * 2;

            came.transform.rotation =
                Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 360);

            downMode = false;
        }


        //底から壁に上がる時
        //上部から出ているRayが当たらなくなったら発動
        if (!rayHead && downUpMode && separateMode)
        {
            transform.position = transform.position + transform.forward * 1f + transform.up * 3;

            //向きを壁側にするために180度回転させる
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 180,
                transform.rotation.z));


            came.transform.rotation =
                Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 360);

            downUpMode = false;
        }

        //背後に壁があったら
        //後方に出ているRayが反応したら発動
        if (rayBack)
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 180,
                transform.rotation.z));

            came.transform.rotation =
                Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 10);

            rayBack = false;
        }


        //隣の壁へ
        //正面から出ているRayが当たらなくなったら発動
        if (!rayDown && upMode && sideMoveMode)
        {
            //D、Aキーの押している方により回転や移動する方向が違う
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + transform.forward * 2f + transform.right;

                transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 90,
                    transform.rotation.z));

                came.transform.rotation =
                    Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 10);
            }


            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + transform.forward * 2f - transform.right;

                transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y - 90,
                    transform.rotation.z));

                came.transform.rotation =
                    Quaternion.RotateTowards(came.transform.rotation, transform.rotation, 10);
            }

            sideMoveMode = false;
        }

    }

    //ギズモでRayが出ている位置を表示
    void OnDrawGizmosSelected()
    {
        //正面中央
        Gizmos.color = Color.red;
        Vector3 direction1 = transform.TransformDirection(new Vector3(0, 0, 2f));
        Gizmos.DrawRay(transform.position, direction1);

        //正面上部
        Gizmos.color = Color.red;
        Vector3 direction2 = transform.TransformDirection(new Vector3(0, 0, 2f));
        Gizmos.DrawRay((new Vector3(transform.position.x, transform.position.y + 0.2f,
            transform.position.z)), direction2);

        //上方へ
        Gizmos.color = Color.red;
        Vector3 direction3 = transform.TransformDirection(new Vector3(0, 3f, 0));
        Gizmos.DrawRay(transform.position, direction3);

        //後方へ
        Gizmos.color = Color.red;
        Vector3 direction4 = transform.TransformDirection(new Vector3(0, 0, -2f));
        Gizmos.DrawRay(transform.position, direction4);
    }
}