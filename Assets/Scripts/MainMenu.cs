using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject backGround;

    [SerializeField]
    float maxX = 2000;
    [SerializeField]
    float minX = -2000;

    [SerializeField]
    float maxY = 1700;
    [SerializeField]
    float minY = 1700;

    Vector3 _bgVelocity = new Vector3(0.1f, 0.1f, 0);
    public void StartNewGame()
    {
        SceneManager.LoadScene("GameBoard");
    }
    public void ExitGame()
    {
        Debug.Log("quiting");
        Application.Quit();
    }
}
