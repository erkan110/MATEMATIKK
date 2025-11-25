using UnityEngine;
using UnityEngine.SceneManagement;

public class SAHNE_BAGLANTİSİ : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("OYUN_ALAN");
    }
    public void toplama()
    {
        SceneManager.LoadScene("TOPLAMA OYUNU");
    }
}
