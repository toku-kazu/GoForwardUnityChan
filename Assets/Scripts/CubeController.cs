using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //AudioSource
    AudioSource audioSource;
   


    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        // キューブを移動させる
        transform.Translate (speed * Time.deltaTime, 0, 0);
        //画面外に出たら破棄する
        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }

        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Cube")
        {
            audioSource.Play();
        }
        
    }

}
