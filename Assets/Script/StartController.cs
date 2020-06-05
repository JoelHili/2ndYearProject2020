using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public void startGame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
