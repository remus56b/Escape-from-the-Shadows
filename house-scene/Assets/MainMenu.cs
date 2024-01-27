using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Începe jocul; poți să încarci scena principală a jocului
        SceneManager.LoadScene("SampleScene");
    }
}
