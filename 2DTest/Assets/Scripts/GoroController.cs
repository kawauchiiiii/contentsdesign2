using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoroController : MonoBehaviour
{
    float speed = -15.0f;

    //魔法のエフェクトノインスタンス

    GameObject GoroEffectClone;


    //魔法のエフェクト

    public GameObject gorogoroeffect;


    private Rigidbody2D rb;

    void Start()
    { 
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.transform.position += this.transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            Destroy(this.gameObject);
            Debug.Log("gorooo");
            Vector2 play = GameObject.Find("Player").transform.position;

        }

        if (collision.gameObject.tag == "Ice")
        {
            Destroy(this.gameObject);
            Debug.Log("icegoro");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            Debug.Log("相手魔法を破壊");
        }

        //ほのお属性の相手を破壊
        if (collision.gameObject.tag == "FlaEnemy")
        {
     
            Vector2 play = collision.gameObject.transform.position;

            GoroEffectClone = Instantiate(gorogoroeffect, play, Quaternion.identity);
            Destroy(GoroEffectClone, 1.0f);

            Destroy(collision.gameObject);
            Debug.Log("炎敵を破壊");
        }


    }
}
