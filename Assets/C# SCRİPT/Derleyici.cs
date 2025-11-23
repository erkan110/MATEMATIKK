using System.Collections;
using TMPro;
using UnityEngine;

public class Derleyici : MonoBehaviour
{
    public TextMeshProUGUI geriyeSaymaText;
    public TextMeshProUGUI Sik1Text;
    public TextMeshProUGUI Sik2Text;
    public TextMeshProUGUI Button1Text;
    public TextMeshProUGUI Button2Text;
    public TextMeshProUGUI Button3Text;
    public TextMeshProUGUI TebriklerText;
    public TextMeshProUGUI SayacText;

    public GameObject Toplama;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public bool soruYoksa;

    public bool Sýk1Dogru;
    public bool Sýk2Dogru;
    public bool Sýk3Dogru;

    public int sik1Sayi;
    public int sik2Sayi;

    public int cevap;
    public int rastgeleSayi;

    public int HangiSikDogru;

    public int dogruCevapSayacý = 0;

    void Start()
    {
        StartCoroutine(GeriSayma());

        Toplama.SetActive(false);
        Sik1Text.enabled = false;
        Sik2Text.enabled = false;
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
    }

    void Update()
    {
        SayacText.text = "Doðru Cevap : " + dogruCevapSayacý.ToString();
    }

    public void SoruÜret()
    {
        sik1Sayi = Random.Range(0, 50);
        sik2Sayi = Random.Range(0, 50);

        cevap = sik1Sayi + sik2Sayi;

        Sik1Text.text = sik1Sayi.ToString();
        Sik2Text.text = sik2Sayi.ToString();

        ButonaAta();
    }

    public void ButonaAta()
    {
        int HangiSikDogru = Random.Range(0, 3);

        if (HangiSikDogru == 0)
        {
            Button1Text.text = cevap.ToString();

            Sýk1Dogru = true;
            Sýk2Dogru = false;
            Sýk3Dogru = false;
        }

        else
        {
            int rastgeleSayi = Random.Range(0, 50);

            Button1Text.text = rastgeleSayi.ToString();

            while (rastgeleSayi == cevap)
            {
                rastgeleSayi = Random.Range(0, 50);

                Button1Text.text = rastgeleSayi.ToString();
            }
        }

        if (HangiSikDogru == 1)
        {
            Button2Text.text = cevap.ToString();

            Sýk1Dogru = false;
            Sýk2Dogru = true;
            Sýk3Dogru = false;
        }

        else
        {
            int rastgeleSayi = Random.Range(0, 50);

            Button2Text.text = rastgeleSayi.ToString();

            while (rastgeleSayi == cevap)
            {
                rastgeleSayi = Random.Range(0, 50);

                Button2Text.text = rastgeleSayi.ToString();
            }
        }

        if (HangiSikDogru == 2)
        {
            Button3Text.text = cevap.ToString();

            Sýk1Dogru = false;
            Sýk2Dogru = false; 
            Sýk3Dogru = true;
        }

        else
        {
            int rastgeleSayi = Random.Range(0, 50);

            Button3Text.text = rastgeleSayi.ToString();

            while (rastgeleSayi == cevap)
            {
                rastgeleSayi = Random.Range(0, 50);

                Button3Text.text = rastgeleSayi.ToString();
            }
        }
    }

    public void Buton1Basýldý()
    {
        if (Sýk1Dogru == true)
        {
            TebriklerText.text = "TEBRÝKLER!";

            dogruCevapSayacý += 1;

            StartCoroutine(TextiSilme());

            SoruÜret();
        }

        else
        {
            TebriklerText.text = "YANLIÞ!";

            StartCoroutine(TextiSilme());

            SoruÜret();
        }
    }

    public void Buton2Basýldý()
    {
        if (Sýk2Dogru == true)
        {
            TebriklerText.text = "TEBRÝKLER!";

            dogruCevapSayacý += 1;

            StartCoroutine(TextiSilme());

            SoruÜret();
        }

        else
        {
            TebriklerText.text = "YANLIÞ!";

            StartCoroutine(TextiSilme());

            SoruÜret();
        }
    }

    public void Buton3Basýldý()
    {
        if (Sýk3Dogru == true)
        {
            TebriklerText.text = "TEBRÝKLER!";

            dogruCevapSayacý += 1;

            StartCoroutine(TextiSilme());

            SoruÜret();
        }

        else
        {
            TebriklerText.text = "YANLIÞ!";

            StartCoroutine(TextiSilme());

            SoruÜret();
        }
    }

    IEnumerator GeriSayma()
    {
        geriyeSaymaText.text = "3";
        yield return new WaitForSeconds(1f);
        geriyeSaymaText.text = "2";
        yield return new WaitForSeconds(1f);
        geriyeSaymaText.text = "1";
        yield return new WaitForSeconds(1f);
        geriyeSaymaText.text = "BAÞLA";
        yield return new WaitForSeconds(0.5f);
        geriyeSaymaText.text = "";

        Toplama.SetActive(true);
        Sik1Text.enabled = true;
        Sik2Text.enabled = true;
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        SoruÜret();
    }

    IEnumerator TextiSilme()
    {
        yield return new WaitForSeconds(1f);
        TebriklerText.text = "";
    }
}