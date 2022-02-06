using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject player_move;

    private Rigidbody2D rb;

    void Start()
    {
        // オブジェクトのRigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
        // PLAYERオブジェクトを取得
        player_move = GameObject.FindGameObjectWithTag("Player");
    }



    // Update is called once per frame
    void Update()
    { // PLAYERの位置を取得
        Vector2 targetPos = player_move.transform.position;
        // PLAYERのx座標
        float x = targetPos.x;
        // ENEMYは、地面を移動させるので座標は常に0とする
        float y = 0;
        // 移動を計算させるための２次元のベクトルを作る
        Vector2 direction = new Vector2(
            x - transform.position.x, y).normalized;
        // ENEMYのRigidbody2Dに移動速度を指定する
        rb.velocity = direction * 5;

    }

 


}
