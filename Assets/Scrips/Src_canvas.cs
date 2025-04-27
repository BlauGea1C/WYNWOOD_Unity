using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Src_canvas : MonoBehaviour
{
    public void ChangeScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
