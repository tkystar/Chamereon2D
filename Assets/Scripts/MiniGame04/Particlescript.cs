using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlescript : MonoBehaviour
{
    
    [SerializeField] ParticleSystem particle;
    float stoptime;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //Objectタグの付いたゲームオブジェクトと衝突したか判別
        {
            
            particle.Play(true);
            Destroy(this.gameObject); //衝突したゲームオブジェクトを削除
            Debug.Log("collide");
            stoptime += Time.deltaTime;
        }

        if (stoptime > 4)
        {
            particle.Stop();
            stoptime = 0;
        }
    }
    void Update()
    {
        particle.Play(true);
        Debug.Log("collide");
    }
}