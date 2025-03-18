using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_CanvasMapa : MonoBehaviour
{
    public void ChangeScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

}
