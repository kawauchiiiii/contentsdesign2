using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public InputField inputField;
    public GameObject gorogoro;
    GameObject GoroClone;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InputText()
    {
        string str = inputField.text;
        string strA = "ÉSÉçÉSÉç";
        string strB = "ÉrÉäÉrÉä";
        if (strA.Equals(str))
            {
            Debug.Log("goro");
            inputField.text = "";
            GoroClone = Instantiate(gorogoro, this.transform.position, this.transform.rotation);
            Destroy(GoroClone, 5.0f);

        }
        else if (strB.Equals(str))
        {
            Debug.Log("biri");
            inputField.text = "";
        }
        else
        {
            Debug.Log("aaaa");
             }

    }
    }
