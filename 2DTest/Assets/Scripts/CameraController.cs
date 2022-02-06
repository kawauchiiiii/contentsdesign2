using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    float speed = 1.5f;

    void Start()
    {// playerObj = GameObject.FindGameObjectWithTag("Player");
        //player = playerObj.GetComponent<PlayerController>();
        //playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        this.transform.position += this.transform.right * speed * Time.deltaTime;
    }
    void MoveCamera()
    {
        //â°ï˚å¸ÇæÇØí«è]
        //transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}