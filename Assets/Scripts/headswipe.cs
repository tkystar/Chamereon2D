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
        ArrowMesh.material.color = new Color32(255, 255, 255, 0);
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
                //sPos = t1.position;
                //ArrowMesh.enabled = true;
                //sRot = tongueroot.transform.rotation;
            }
            else if (t1.phase == TouchPhase.Moved || t1.phase == TouchPhase.Stationary)
            {
                Vector2 touchworldposition = Camera.main.ScreenToWorldPoint(t1.position);//マウス座標をワールド座標に変換
                float degree_z = GetAngle(this.transform.position, touchworldposition) + 180;//2点間の角度の計算
                degree_z = (degree_z> 180) ? degree_z - 360 : degree_z;
                // 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする
                float angleZ = Mathf.Clamp(degree_z, minAngle, maxAngle);
                // 回転角度を-180～180から0～360に変換
                angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;
                // 回転角度をオブジェクトに適用
                transform.rotation = Quaternion.Euler(0, 0, angleZ);

                //tongueroot.transform.rotation = sRot;
                //tongueroot.transform.Rotate(new Vector3(0, 0, 90 * ty), Space.Self);
            }
            //ArrowMesh.enabled = false;
        }
    }

    void MouseTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*sPos = Input.mousePosition;
            //sRot = tongueroot.transform.rotation;
            ArrowMesh.enabled = true;*/
            ArrowMesh.material.color = new Color32(255, 255, 255, 255);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 touchworldposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウス座標をワールド座標に変換
            float degree_z = GetAngle(this.transform.position,touchworldposition) + 180;
            degree_z = (degree_z> 180) ? degree_z - 360 : degree_z;
            // 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする
            float angleZ = Mathf.Clamp(degree_z , minAngle, maxAngle);
            // 回転角度を-180～180から0～360に変換
            angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;
            // 回転角度をオブジェクトに適用
            transform.rotation = Quaternion.Euler(0, 0, angleZ);
            //float rotateZ = (transform.eulerAngles.z > 180) ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
            //float angleZ = Mathf.Clamp(rotateZ + ty, minAngle, maxAngle);
            //angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;
            //transform.rotation = Quaternion.Euler(0, 0, angleZ);
            // tongueroot.transform.rotation = sRot;
            //tongueroot.transform.Rotate(new Vector3(0, 0, -90 * ty), Space.Self);

        }
        //ArrowMesh.enabled = false;
        ArrowMesh.material.color = new Color32(255, 255, 255, 0);
    }

    float GetAngle(Vector2 start,Vector2 target)//2点間の角度を求める
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        //Debug.Log(degree);
        return degree;
    }
}
