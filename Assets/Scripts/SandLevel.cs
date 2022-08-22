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
         
        if (other.tag == "Grain")
        {


            //calls get and set functions to update player life counts and destory if less than 1
            this.gameObject.transform.localScale += new Vector3(0, .5f, 0);
            this.gameObject.transform.position = transform.position + new Vector3(0, .25f, 0);
            Destroy(other.gameObject);
             
            //stop spawing enemies
            //make if statment to kill player
        }
        if(other.tag=="Player_Head")
        {
           // Debug.Log("Game Over");
            GameObject.FindGameObjectsWithTag("SceneManger")[0].GetComponent<LoadScene>().GameOver();
        }
    
    }
}
