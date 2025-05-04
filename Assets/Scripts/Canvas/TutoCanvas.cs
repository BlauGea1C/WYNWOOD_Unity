using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject canvasTutorial;
    public GameObject mira;
    public AudioSource audioSourceBotones;
    void Start()
    {
        // Si el canvas del tutorial está activo, desbloquear el cursor
        if (canvasTutorial != null && canvasTutorial.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (mira != null)
                mira.SetActive(false);
        }
    }

    public void CerrarTutorial()
    {
        audioSourceBotones.Play();
        canvasTutorial.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (mira != null)
            mira.SetActive(true);
    }
}