using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Src_canvas : MonoBehaviour
{
    public AudioSource audioSourceBotones;

 
    public void ChangeScene(int Scene)
    {
        PlayClickSound();
        SceneManager.LoadScene(Scene);
    }

    public void ExitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    private void PlayClickSound()
    {
        if (audioSourceBotones != null)
        {
            audioSourceBotones.Play(); // Usa el AudioClip que ya tiene el AudioSource asignado
        }
    }
}
