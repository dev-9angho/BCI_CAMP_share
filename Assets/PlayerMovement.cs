using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private Rigidbody rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 0.1f;
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rigid.AddForce(new Vector3(h, 0, v) * speed);
    }
}
