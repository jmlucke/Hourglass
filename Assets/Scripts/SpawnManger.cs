using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField]
    private bool isEnemySpawnActive = true;
    //Enememy
    public GameObject grainPrefab;
    //two and half second delay. Could be longer and vary in the future.
    public float spawnRate = .5f;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        //Waits a certain amount of time and the will spawn a new enemy.
        while (isEnemySpawnActive)
        {
            //To determine spawn location needs to be set Y but variable X.
            //Currently random but could be a pattern.
            Instantiate(grainPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }



    }

    public void SetIsEnemySpawnActive(bool spawn)
    {
        isEnemySpawnActive = spawn;
    }
}
