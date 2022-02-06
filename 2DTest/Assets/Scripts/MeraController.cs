using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeraController : MonoBehaviour
{
    GameObject IceClone;


    public GameObject IceEnemy;


    //魔法のエフェクトノインスタンス

    GameObject MeraEffectClone;


    //魔法のエフェクト

    public GameObject merameraeffect;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            Debug.Log("相手魔法を破壊");
        }

        //koori属性の相手を破壊
        if (collision.gameObject.tag == "IceEnemy")
        {

            Vector2 play = collision.gameObject.transform.position;

            MeraEffectClone = Instantiate(merameraeffect, play, Quaternion.identity);
            Destroy(MeraEffectClone, 1.0f);

            Destroy(collision.gameObject);
            Debug.Log("氷敵を破壊");

     
        }


    }

  
}
