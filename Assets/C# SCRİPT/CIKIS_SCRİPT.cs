using UnityEngine;

public class CIKIS_SCRİPT : MonoBehaviour
{
    public GameObject cikisKUTU;

    public void Start()
    {
        cikisKUTU.SetActive(false); 
    }

    public void kutuAC()
    {
        cikisKUTU.SetActive(true);
    }
    public void cik()
    {
        Application.Quit();
        cikisKUTU.SetActive(false);
    }
    public void cikma()
    {
        cikisKUTU.SetActive(false);
    }
}
