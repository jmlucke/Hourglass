using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_player : MonoBehaviour
{
    // Start is called before the first frame update'
    Animator anim;
    float _moveSpeed, _speed, horizontalMove;
    
    public float jumpForce = 2000;
    //public float gravity = -9.81f;
    bool jumpRefresh = true;
    //loat velocity;
    Rigidbody2D m_Rigidbody;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        _moveSpeed = 5f;
        _speed = 7f;
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        m_Rigidbody = GetComponent<Rigidbody2D>();
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
        horizontalMove = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        transform.Translate(direction * _speed * Time.deltaTime);

        if (horizontalMove != 0 && !anim.GetBool("Jump"))
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", true);
            // anim.SetTrigger("Human_Running");
            //GetComponent<Animation>().Play("Pirat01_Walking");
          //  Debug.Log("Walking now");
        }
        else if(anim.GetBool("Jump"))
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Idle", false);
          //  Debug.Log("Jump test");
        }
        else
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Walking", false);
            anim.SetBool("Idle", true);
         //   Debug.Log("Idle now");
        }
    }
    void Jump()
    {
        {
            if ((Input.GetKeyDown(KeyCode.Space)) && jumpRefresh)
            {
                //Jump Script
                m_Rigidbody.AddForce(Vector3.up * jumpForce);
                SetJumpRefresh(false);
                anim.SetBool("Jump", true);
                Debug.Log("Jump to true");
            }
        }
    }

    public void SetJumpRefresh(bool canJump)
    {
        jumpRefresh = canJump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision occured");
        if (collision.rigidbody.tag == "Floor" || collision.rigidbody.tag == "Platform")
        {
            if (collision.contacts[0].point.y < this.transform.position.y)
            {
                SetJumpRefresh(true);
                anim.SetBool("Jump", false);
            }

        }
    }
}
