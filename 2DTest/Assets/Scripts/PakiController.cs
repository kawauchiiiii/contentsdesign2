using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PakiController : MonoBehaviour
{
    float speed = -10f;

    //魔法のエフェクトノインスタンス

    GameObject PakiEffectClone;


    //魔法のエフェクト

    public GameObject pakipakieffect;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            Debug.Log("相手魔法を破壊");
        }

        //ほのお属性の相手を破壊
        if (collision.gameObject.tag == "EleEnemy")
        {

            Vector2 play = collision.gameObject.transform.position;

            PakiEffectClone = Instantiate(pakipakieffect, play, Quaternion.identity);
            Destroy(PakiEffectClone, 1.0f);

            Destroy(collision.gameObject);
            Debug.Log("電気敵を破壊");
        }


    }
}
