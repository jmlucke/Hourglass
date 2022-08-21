using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float _speed = 7f;
    public float jumpForce = 2000;
    //public float gravity = -9.81f;
    bool jumpRefresh = true;
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
            if ((Input.GetKeyDown(KeyCode.Space)) && jumpRefresh)
            {
                //Jump Script
                Debug.Log("Jump?");
                m_Rigidbody.AddForce(Vector3.up * jumpForce);
                SetJumpRefresh(false);
            }
            //float verticalInput = Input.GetAxis("Vertical");
            // direction is a composite of vertical and horizontal
            //Vector3 direction = new Vector3(0, velocity, 0);
            //  transform.Translate(direction * Time.deltaTime);
        }
    }
    
    public void SetJumpRefresh(bool canJump)
    {
        jumpRefresh = canJump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         
      //  Debug.Log("Test output coll 11 " + collision.rigidbody.tag);
      //  Debug.Log("Test output coll 12" + this.tag);
       // Debug.Log("Test output coll 11" + collision.contacts[0].point.y);
      //  Debug.Log("Test output coll 12" + this.transform.position);
        if (collision.rigidbody.tag == "Floor" || collision.rigidbody.tag == "Platform")
        {
            if(collision.contacts[0].point.y< this.transform.position.y)
            {
                GameObject.Find("Player").GetComponent<Player>().SetJumpRefresh(true);
            }
             
        }
    }
}
