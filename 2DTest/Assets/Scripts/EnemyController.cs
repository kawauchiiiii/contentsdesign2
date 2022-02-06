using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject player_move;

    private Rigidbody2D rb;

    void Start()
    {
        // �I�u�W�F�N�g��Rigidbody2D���擾
        rb = GetComponent<Rigidbody2D>();
        // PLAYER�I�u�W�F�N�g���擾
        player_move = GameObject.FindGameObjectWithTag("Player");
    }



    // Update is called once per frame
    void Update()
    { // PLAYER�̈ʒu���擾
        Vector2 targetPos = player_move.transform.position;
        // PLAYER��x���W
        float x = targetPos.x;
        // ENEMY�́A�n�ʂ��ړ�������̂ō��W�͏��0�Ƃ���
        float y = 0;
        // �ړ����v�Z�����邽�߂̂Q�����̃x�N�g�������
        Vector2 direction = new Vector2(
            x - transform.position.x, y).normalized;
        // ENEMY��Rigidbody2D�Ɉړ����x���w�肷��
        rb.velocity = direction * 5;

    }

 


}
