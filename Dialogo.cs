using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject DialogoPanel;
    [SerializeField, TextArea(4, 8)] private string[] dialogoLines;
    [SerializeField] private TMP_Text dialogoText;

    private float typingTime = 0.05f;

   private bool isPlayerInRange;
   private bool didDialogoStart;
   private int lineIndex;

   void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
           if(!didDialogoStart)
            {
                StartDialogo();
            }
            else if (dialogoText.text == dialogoLines[lineIndex])
            {
                NextDialogoLine();
            }
        }
    }  
    void StartDialogo()
    {
        didDialogoStart = true;
        DialogoPanel.SetActive(true);
        circle.SetActive(false);
        lineIndex = 0;  
        StartCoroutine(ShowLine());
    }

    private void NextDialogoLine()
    {
        lineIndex++;

        if (lineIndex < dialogoLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogoStart = false;
            DialogoPanel.SetActive(false);
            circle.SetActive(true);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogoText.text = string.Empty;

        foreach (char ch in dialogoLines[lineIndex])
        {
            dialogoText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            circle.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            circle.SetActive(false);
        }
    }
}
