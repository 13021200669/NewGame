using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    
    public Transform CameraSystem;
    public float Speed = 10;
    public float JumpForce = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += CameraSystem.right * x * Time.deltaTime * Speed;
        transform.position += CameraSystem.forward * z * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += CameraSystem.up * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= CameraSystem.up * Time.deltaTime * Speed;
        }
    }
}
