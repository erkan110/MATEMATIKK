using UnityEngine;

public class CIKIS_SCRİPT : MonoBehaviour
{
    public GameObject cikisKUTU;

    public void kutuAC()
    {
        cikisKUTU.SetActive(false);
    }
    public void cik()
    {
        cikisKUTU.SetActive(true);
    }
    public void cikma()
    {
        cikisKUTU.SetActive(false);
    }
}
