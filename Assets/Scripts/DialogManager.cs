using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public TextMeshProUGUI messageText;
    private Coroutine messageCoroutine;

    private void Start()
    {
        // Agrega contorno negro al texto
        messageText.outlineColor = Color.black;
        messageText.outlineWidth = 0.2f; // Ajusta según lo que necesites
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMessage(string message, float duration = 2f)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }
        messageCoroutine = StartCoroutine(ShowMessageCoroutine(message, duration));
    }

    private IEnumerator ShowMessageCoroutine(string message, float duration)
    {
        messageText.text = message;
        messageText.alpha = 1;
        yield return new WaitForSeconds(duration);
        messageText.alpha = 0;
    }
}

