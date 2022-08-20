using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Test output coll " + other.tag);
        if (other.tag == "Grain")
        {

            //calls get and set functions to update player life counts and destory if less than 1
             
                Destroy(other.gameObject);
                //stop spawing enemies
             


        }
    
    }
}
