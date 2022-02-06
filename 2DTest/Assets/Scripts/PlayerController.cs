using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;


    public Image hpimage;

    //魔法の上限

    public Image iceimage;
    public Image eleimage;
    public Image flaimage;

    //魔法入力

    public InputField inputField;


    //魔法のインスタンス

    GameObject GoroClone;
    GameObject MeraClone;
    GameObject PakiClone;

    //魔法

    public GameObject gorogoro;
    public GameObject pakipaki;
    public GameObject meramera;


    //魔法のエフェクトノインスタンス

    GameObject GoroEffectClone;
    GameObject MeraEffectClone;
    GameObject PakiEffectClone;

    //魔法のエフェクト

    public GameObject gorogoroeffect;
    public GameObject pakipakieffect;
    public GameObject merameraeffect;


    //魔法吸収後のオブジェクト

    GameObject IceObject;
    GameObject EleObject;
    GameObject FlaObject;

    //魔法吸収後のオブジェクトのインスタンス

    public GameObject post_ice;
    public GameObject post_ele;
    public GameObject post_fla;

    public GameObject Player;

    public AudioClip runsound;
    public AudioClip jumpsound;
    public AudioClip magicsound;

    public AudioClip icesound;
    public AudioClip elesound;
    public AudioClip flasound;

    public AudioClip icemagicsound;
    public AudioClip elemagicsound;
    public AudioClip flamagicsound;

    AudioSource audioSource;

    float maxHP = 5;
    float currentHP = 5;

    float MagicHP = 3;

    float currentIceHP = 3;
    float currentEleHP = 3;
    float currentFlaHP = 3;

    [SerializeField] Animator AnimationImage = null;
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();

        audioSource = this.gameObject.GetComponent<AudioSource>();


    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        if (Input.GetKeyDown("t"))
        {
            Debug.Log("t");
            inputField.ActivateInputField();
            inputField.text = "";
        }

        if (Input.GetKeyDown("return"))
        {
            Debug.Log("return");
            inputField.DeactivateInputField();
            inputField.text = "";
        }



        if (isMoving)
        {
           
            Vector3 scale = gameObject.transform.localScale;
            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
              
                scale.x *= -1;
                
            }
            gameObject.transform.localScale = scale;


        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping && !isFalling)
        {
          
            Jump();

        }



        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    void Jump()
    {
        inputField.DeactivateInputField();

        isJumping = true;
        
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.clip = jumpsound;
        audioSource.PlayOneShot(jumpsound);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
        }

        // オブジェクトに当たった時に吸収するコマンド

        if (collision.gameObject.tag == "Ice")
        {
            //氷

            Vector2 play = (collision.gameObject.transform.position);
            IceObject = Instantiate(post_ice, play, Quaternion.identity);

            audioSource.clip = icesound;
            audioSource.PlayOneShot(icesound);
            Destroy(collision.gameObject);

            if (currentIceHP < 3)
            {

                currentIceHP += 1;
                iceimage.fillAmount = currentIceHP / MagicHP;

            }
        }

        if (collision.gameObject.tag == "Flame")
        {
            //ほのお

            Vector2 play = (collision.gameObject.transform.position);
            play.y -= 1.0f;
            FlaObject = Instantiate(post_fla, play, Quaternion.identity);

            audioSource.clip = flasound;
            audioSource.PlayOneShot(flasound);

            Destroy(collision.gameObject);
            Debug.Log(currentFlaHP);

            if (currentFlaHP < 3)
            {
                currentFlaHP += 1;
                flaimage.fillAmount = currentFlaHP / MagicHP;
            }
        }

        if (collision.gameObject.tag == "Electricity")
        {
            //でんき

            Vector2 play = GameObject.FindWithTag("Electricity").transform.position;
            FlaObject = Instantiate(post_ele, play, Quaternion.identity);

            audioSource.clip = elesound;
            audioSource.PlayOneShot(elesound);

            Destroy(collision.gameObject);

            if (currentEleHP < 3)
            {
                currentEleHP += 1;
                eleimage.fillAmount = currentEleHP / MagicHP;

            }
        }
        //回復アイテム

        if (collision.gameObject.tag == "Item")
        {

            if (currentHP < 5)
            {
                currentHP += 1;
                hpimage.fillAmount = currentHP / maxHP;
            }

        }
        //敵魔法に当たった時

        if (collision.gameObject.tag == "Enemy")
        {
            currentHP -= 1;
            hpimage.fillAmount = currentHP / maxHP;
            Destroy(collision.gameObject);
        }

        //敵に当たった時

        else if (collision.gameObject.tag == "FlaEnemy" || collision.gameObject.tag == "IceEnemy" || collision.gameObject.tag == "EleEnemy")
        {

            Debug.Log("死にました");

        }

    }
    public void InputText()
    {
        //呪文生成

        string str = inputField.text;

        string strA = "ゴロゴロ";
        string strB = "メラメラ";
        string strC = "パキパキ";

        if (strA.Equals(str)&& currentEleHP >= 1)
        {
            //雷

            Debug.Log("ゴロゴロ");

            inputField.DeactivateInputField();

            Vector2 play1 = GameObject.FindGameObjectWithTag("Player").transform.position;

            play1.x += 5.0f;
            play1.y += 8.0f;
 
            GoroClone = Instantiate(gorogoro, play1, Quaternion.identity);


            Vector2 play2 = GameObject.FindGameObjectWithTag("Player").transform.position;

            play2.x += -5.0f;
            play2.y += 8.0f;

            GoroClone = Instantiate(gorogoro, play2, Quaternion.identity);

            AnimationImage.SetTrigger("Attacking");          
            AnimationImage.SetTrigger("Stopping");

            currentEleHP -= 1;
            eleimage.fillAmount = currentEleHP / MagicHP;

            audioSource.clip = elemagicsound;
            audioSource.PlayOneShot(elemagicsound); 

        }
        else if (strB.Equals(str) && currentFlaHP >= 1)
        {
            //ほのお

            Debug.Log("メラメラ");

            inputField.DeactivateInputField();

            Vector2 play = GameObject.FindGameObjectWithTag("Player").transform.position;

            MeraClone = Instantiate(meramera, play, Quaternion.identity);
            Destroy(MeraClone, 5.0f);


            AnimationImage.SetTrigger("Attacking");
            AnimationImage.SetTrigger("Stopping");

            currentFlaHP -= 1;
            flaimage.fillAmount = currentFlaHP / MagicHP;

            audioSource.clip = flamagicsound;
            audioSource.PlayOneShot(flamagicsound);
        }
        else if (strC.Equals(str) && currentIceHP >= 1)
        {
            //こおり

            Debug.Log("パキパキ");

            inputField.DeactivateInputField();

            Vector2 play = GameObject.FindGameObjectWithTag("Player").transform.position;

            PakiClone = Instantiate(pakipaki, play, Quaternion.identity);
            Destroy(PakiClone, 5.0f);

            AnimationImage.SetTrigger("Attacking");
            AnimationImage.SetTrigger("Stopping");

            currentIceHP -= 1;
            iceimage.fillAmount = currentIceHP / MagicHP;

            audioSource.clip = icemagicsound;
            audioSource.PlayOneShot(icemagicsound);
        }
        else
        {

        }

    }
    private void OnCollisionEnter2D(Collision2D collision) {

   
    }

}

