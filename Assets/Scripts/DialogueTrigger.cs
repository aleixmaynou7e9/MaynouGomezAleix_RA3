using UnityEngine;
using TMPro; // Si usas TextMeshPro

public class DialogueTrigger : MonoBehaviour
{
    [Header("UI del Diálogo")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    [Header("Contenido")]
    [TextArea(3, 5)]
    public string message = "Press Space to change your gravity";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null) dialogueText.text = message;
            if (dialoguePanel != null) dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialoguePanel != null) dialoguePanel.SetActive(false);
        }
    }
}