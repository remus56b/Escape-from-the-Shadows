using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{
    public void PlayButton()
    {
        // Începe jocul; poți să încarci scena principală a jocului
        SceneManager.LoadScene("SampleScene");
    }
}