using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiriController : MonoBehaviour
{
    float speed = 2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.right* speed * Time.deltaTime;
    }
}
