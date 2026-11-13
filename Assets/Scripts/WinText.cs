using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
    public TMP_Text textoUI;

    void Update()
    {
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        textoUI.text = MySceneManager.youWin ? "YOU WIN!" : "Game Over";
    }
}
