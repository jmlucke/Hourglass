using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Game_Over");
    }
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

}
