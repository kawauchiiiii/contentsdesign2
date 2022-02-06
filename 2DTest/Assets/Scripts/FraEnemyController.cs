using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraEnemyController : MonoBehaviour
{
    public float span = 5f;
    private float currentTime = 0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] Animator AnimationImage = null;
    GameObject player_move;

    float speed = 1.8f;

    GameObject PachiClone;
    GameObject PachiEffect;

    public GameObject pachipachi;

    public AudioClip pachisound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        player_move = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
            if (currentTime < span && currentTime > 0f )
            {
                // PLAYER�̈ʒu���擾
                Vector2 targetPos = player_move.transform.position;
                // PLAYER��x���W
                float x = targetPos.x;
                // ENEMY�́A�n�ʂ��ړ�������̂ō��W�͏��0�Ƃ���
                float y = 0;
                // �ړ����v�Z�����邽�߂̂Q�����̃x�N�g�������
                Vector2 direction = new Vector2(
                    x - transform.position.x, y).normalized;
                // ENEMY��Rigidbody2D�Ɉړ����x���w�肷��
                rb.velocity = direction * speed;
    

        }

            else if (currentTime > span && collision.gameObject.tag == "Stage")
            {
                currentTime =-0.65f;
                AnimationImage.SetTrigger("FlaAttacking");
                Debug.Log("�p�`�p�`");

                Vector2 play = this.transform.position;


                play.x += 1f;
            play.y += -1f;


            PachiClone = Instantiate(pachipachi, play, Quaternion.identity);
                Destroy(PachiClone, 5.0f);


                AnimationImage.SetTrigger("FlaStopping");




        }
    }

  


   
}






