using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeraController : MonoBehaviour
{
    GameObject IceClone;


    public GameObject IceEnemy;


    //@ฬGtFNgmCX^X

    GameObject MeraEffectClone;


    //@ฬGtFNg

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
            Debug.Log("่@๐j๓");
        }

        //kooriฎซฬ่๐j๓
        if (collision.gameObject.tag == "IceEnemy")
        {

            Vector2 play = collision.gameObject.transform.position;

            MeraEffectClone = Instantiate(merameraeffect, play, Quaternion.identity);
            Destroy(MeraEffectClone, 1.0f);

            Destroy(collision.gameObject);
            Debug.Log("XG๐j๓");

     
        }


    }

  
}
