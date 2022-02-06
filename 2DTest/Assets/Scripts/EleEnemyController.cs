using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleEnemyController : MonoBehaviour
{
    public float span = 5f;
    private float currentTime = 0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] Animator AnimationImage = null;
    GameObject player_move;

    float speed = 1.8f;

    GameObject BiriClone;

    public GameObject biribiri;

    public AudioClip birisound;
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
        if (currentTime < span && currentTime > 0f)
        {
            // PLAYERの位置を取得
            Vector2 targetPos = player_move.transform.position;
            // PLAYERのx座標
            float x = targetPos.x;
            // ENEMYは、地面を移動させるので座標は常に0とする
            float y = 0;
            // 移動を計算させるための２次元のベクトルを作る
            Vector2 direction = new Vector2(
                x - transform.position.x, y).normalized;
            // ENEMYのRigidbody2Dに移動速度を指定する
            rb.velocity = direction * speed;


        }

        else if (currentTime > span && collision.gameObject.tag == "Stage")
        {
            currentTime = -0.65f;
            AnimationImage.SetTrigger("EleAttacking");
            Debug.Log("asssadsfghjfdgaaa");

            Vector2 play = this.transform.position;


            play.x += 1f;
            play.y += 2.5f;


            BiriClone = Instantiate(biribiri, play, Quaternion.identity);
            Destroy(BiriClone, 5.0f);


            AnimationImage.SetTrigger("EleStopping");




        }
    }
}
