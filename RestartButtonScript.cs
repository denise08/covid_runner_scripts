using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Pressed play");
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void instructions()
    {
        SceneManager.LoadScene(4);
    }
}
