using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float _speed = 7f;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    //loat velocity;
    Rigidbody2D m_Rigidbody;
    void Start()
    {
        m_Rigidbody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();


    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // direction is a composite of vertical and horizontal
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }
    void Jump()
    {
        // velocity += gravity * Time.deltaTime;
        {
            if ((Input.GetKeyDown(KeyCode.Space)))
            {
                //Jump Script
                Debug.Log("Jump?");
                m_Rigidbody.AddForce(Vector3.up * 2000);

            }
            //float verticalInput = Input.GetAxis("Vertical");
            // direction is a composite of vertical and horizontal
            //Vector3 direction = new Vector3(0, velocity, 0);
            //  transform.Translate(direction * Time.deltaTime);
        }
    }
    
}
