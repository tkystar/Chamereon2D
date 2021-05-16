using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headswipe : MonoBehaviour
{
    private GameObject tongueroot;
    public GameObject ArrowImage;
    private MeshRenderer ArrowMesh;

    Vector2 sPos;   //タッチした座標
    Quaternion sRot;//タッチしたときの回転
    float wid, hei, diag;  //スクリーンサイズ
    float tx, ty;    //変数

    float maxAngle = 30; // 最大回転角度
    float minAngle = -30; // 最小回転角度

    void Start()
    {
        tongueroot = this.gameObject;
        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
        sRot = tongueroot.transform.rotation;
        sRot.z = 0;
        ArrowMesh = ArrowImage.GetComponent<MeshRenderer>();
        ArrowMesh.enabled = false;
    }

    private void Update()
    {
        ScreenTouch();
        MouseTouch();     
    }

    void ScreenTouch()
    {
        if (Input.touchCount == 1)
        {
            //回転
            Touch t1 = Input.GetTouch(0);
            if (t1.phase == TouchPhase.Began)
            {
                sPos = t1.position;
                ArrowMesh.enabled = true;
                //sRot = tongueroot.transform.rotation;
            }
            else if (t1.phase == TouchPhase.Moved || t1.phase == TouchPhase.Stationary)
            {
             
                //tx = (t1.position.x - sPos.x) / wid; //横移動量(-1<tx<1)
                ty = (t1.position.y - sPos.y) / hei; //縦移動量(-1<ty<1)

                float rotateZ = (transform.eulerAngles.z > 180) ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
                // 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする
                float angleZ = Mathf.Clamp(rotateZ + ty, minAngle, maxAngle);
                // 回転角度を-180～180から0～360に変換
                angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;
                // 回転角度をオブジェクトに適用
                transform.rotation = Quaternion.Euler(0, 0, angleZ);

                //tongueroot.transform.rotation = sRot;
                //tongueroot.transform.Rotate(new Vector3(0, 0, 90 * ty), Space.Self);
            }
            ArrowMesh.enabled = false;
        }
    }

    void MouseTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sPos = Input.mousePosition;
            //sRot = tongueroot.transform.rotation;
            ArrowMesh.enabled = true;
        }
        else if (Input.GetMouseButton(0))
        {
            ty = (Input.mousePosition.y - sPos.y) / hei;

            float rotateZ = (transform.eulerAngles.z > 180) ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
            // 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする
            float angleZ = Mathf.Clamp(rotateZ + ty, minAngle, maxAngle);
            // 回転角度を-180～180から0～360に変換
            angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;
            // 回転角度をオブジェクトに適用
            transform.rotation = Quaternion.Euler(0, 0, angleZ);

           // tongueroot.transform.rotation = sRot;
           //tongueroot.transform.Rotate(new Vector3(0, 0, -90 * ty), Space.Self);
            
            
            
        }
        ArrowMesh.enabled = false;
    }
}
