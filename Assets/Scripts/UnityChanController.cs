using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    // ジャンプの速度の減衰
    float dump = 0.8f;

    // ジャンプの速度
    float jumpVelocity = 20;

    // 地面の位置
    float groundLevel = -3.0f;

    // ゲームオーバになる位置
    float deadLine = -9;

    // Use this for initialization
    void Start ()
    {
        // アニメータのコンポーネントを取得する
        animator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > groundLevel) ? false : true;
        animator.SetBool("isGround", isGround);

        // ジャンプ状態のときにはボリュームを0にする
        GetComponent<AudioSource>().volume = isGround ? 1 : 0;

        // 着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける
            rigid2D.velocity = new Vector2(0, jumpVelocity);
        }
        // クリックをやめたら上方向への速度を減速する
        if(Input.GetMouseButton(0) == false)
        {
            if (rigid2D.velocity.y > 0)
            {
                rigid2D.velocity *= dump;

            }
        }

        // デッドラインを超えた場合ゲームオーバにする
        if (transform.position.x < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ユニティちゃんを破棄する
            Destroy(gameObject);
        }
    }
}
