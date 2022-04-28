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
    public void Update()
    {
        /*
        backGround.transform.position += _bgVelocity;
        if(backGround.transform.position.x > maxX)
        {
            _bgVelocity.y *= -1f;
            Debug.Log("right");
        }
        if(backGround.transform.position.x < minX)
        {
            _bgVelocity.y *= -1f;
            Debug.Log("left");
        }

        if(backGround.transform.position.y > maxY)
        {
            _bgVelocity.x *= -1f;
            Debug.Log("top");
        }
            
        if(backGround.transform.position.y < minY)
        {
            _bgVelocity.x *= -1f;
            Debug.Log("bottom");
        }
        */
            
        //if (backGround.transform.position.x > maxX || backGround.transform.position.x < minX)
        //    backGround.transform.position = new Vector3(backGround.transform.position.x*-1f, backGround.transform.position.y, backGround.transform.position.z);
        //if (backGround.transform.position.y > maxY || backGround.transform.position.y < minY)
        //    backGround.transform.position = new Vector3(backGround.transform.position.x, backGround.transform.position.y * -1f, backGround.transform.position.z);
    }
}
