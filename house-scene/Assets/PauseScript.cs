using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public void PauseButton()
    {
        // Începe jocul; poți să încarci scena principală a jocului
        SceneManager.LoadScene("MainMenu");
    }
}