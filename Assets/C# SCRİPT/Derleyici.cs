using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public TextMeshProUGUI KomboText;
    public TextMeshProUGUI CanText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI SureYazýsý;

    public GameObject Toplama;
    public GameObject Sayac;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Panel;
    public GameObject Kalp1;
    public GameObject Kalp2;
    public GameObject Kalp3;
    public GameObject SoruPaneli;
    public GameObject SureText;

    public bool soruYoksa;

    public bool Sýk1Dogru;
    public bool Sýk2Dogru;
    public bool Sýk3Dogru;

    public int sik1Sayi;
    public int sik2Sayi;

    public int cevap;
    public int rastgeleSayi;

    public int HangiSikDogru;

    public int sure;

    public int dogruCevapSayacý = 0;
    public int yanlýsCevap = 0;
    public int can = 3;

    public int komboStreak;

    void Start()
    {
        StartCoroutine(GeriSayma());

        can = 3;
        sure = 30;
        Time.timeScale = 1f;

        Toplama.SetActive(false);
        Sik1Text.enabled = false;
        Sik2Text.enabled = false;
        SayacText.enabled = false;
        CanText.enabled = false;
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Panel.SetActive(false);
        SureText.SetActive(false);
        SoruPaneli.SetActive(false);
        Kalp1.gameObject.SetActive(true);
        Kalp2.gameObject.SetActive(true);
        Kalp3.gameObject.SetActive(true);

    }

    void Update()
    {
        SayacText.text = "CORRECT ANSWER: " + dogruCevapSayacý.ToString();

        SureYazýsý.text = "Time : " + sure.ToString();

        CanText.text = "Can : " + can.ToString();

        if (yanlýsCevap == 3)
        {
            Toplama.SetActive(false);
            Sik1Text.enabled = false;
            Sik2Text.enabled = false;
            SayacText.enabled = false;
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);

            TebriklerText.text = "WRONG";

            Time.timeScale = 0f;

            Panel.SetActive(true);
            ScoreText.text = "SCORE: " + dogruCevapSayacý.ToString();
        }

        if (sure == 0)
        {
            Toplama.SetActive(false);
            Sik1Text.enabled = false;
            Sik2Text.enabled = false;
            SayacText.enabled = false;
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);

            TebriklerText.text = "TIMES UP!";

            Time.timeScale = 0f;

            Panel.SetActive(true);
            ScoreText.text = "SCORE: " + dogruCevapSayacý.ToString();
        }
    } 

    public void SoruÜret()
    {
        sik1Sayi = Random.Range(0, 50);
        sik2Sayi = Random.Range(0, 50);

        cevap = sik1Sayi + sik2Sayi;

        Sik1Text.text = sik1Sayi.ToString();
        Sik2Text.text = sik2Sayi.ToString();

        StartCoroutine(SoruBasýnaSure());

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
            TebriklerText.text = "CONGRATULATIONS!";

            dogruCevapSayacý += 1;
            komboStreak += 1;
            sure = 30;

            KomboText.text = "x" + komboStreak.ToString();

            StartCoroutine(TextiSilme());
            StopCoroutine(SoruBasýnaSure());

            SoruÜret();
        }

        else
        {
            TebriklerText.text = "WRONG!";
            KomboText.text = "";

            StartCoroutine(TextiSilme());
            StopCoroutine(SoruBasýnaSure());

            yanlýsCevap += 1;
            komboStreak = 0;
            can--;
            sure -= 5;

            kalpler();
            SoruÜret();
        }
    }

    public void Buton2Basýldý()
    {
        if (Sýk2Dogru == true)
        {
            TebriklerText.text = "CONGRATULATIONS!";

            dogruCevapSayacý += 1;
            komboStreak += 1;
            sure = 30;

            KomboText.text = "x" + komboStreak.ToString();

            StartCoroutine(TextiSilme());
            StopCoroutine(SoruBasýnaSure());

            SoruÜret();
        }

        else
        {
            TebriklerText.text = "WRONG!";
            KomboText.text = "";

            StartCoroutine(TextiSilme());
            StopCoroutine(SoruBasýnaSure());

            yanlýsCevap += 1;
            komboStreak = 0;
            can--;
            sure -= 5;

            kalpler();
            SoruÜret();
        }
    }

    public void Buton3Basýldý()
    {
        if (Sýk3Dogru == true)
        {
            TebriklerText.text = "CONGRATULATIONS!";

            dogruCevapSayacý += 1;
            komboStreak += 1;
            sure = 30;

            KomboText.text = "x" + komboStreak.ToString();
            StopCoroutine(SoruBasýnaSure());

            StartCoroutine(TextiSilme());

            SoruÜret();
        }

        else
        {
            TebriklerText.text = "YANLIÞ!";
            KomboText.text = "";

            StartCoroutine(TextiSilme());
            StopCoroutine(SoruBasýnaSure());

            yanlýsCevap += 1;
            komboStreak = 0;
            can--;
            sure -= 5;

            kalpler();
            SoruÜret();
        }
    }

    public void YenidenOynama()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void ÇýkýþYapma()
    {
        SceneManager.LoadScene(0);
    }
    public void kalpler()
    {

        if (can == 3)
        {
            Kalp1.gameObject.SetActive(true);
            Kalp2.gameObject.SetActive(true);
            Kalp3.gameObject.SetActive(true);
        }

        if (can == 2)
        {
            Kalp1.gameObject.SetActive(true);
            Kalp2.gameObject.SetActive(true);
            Kalp3.gameObject.SetActive(false);
        }

        if (can == 1)
        {
            Kalp1.gameObject.SetActive(true);
            Kalp2.gameObject.SetActive(false);
            Kalp3.gameObject.SetActive(false);
        }

        if (can == 0)
        {
            Kalp1.gameObject.SetActive(false);
            Kalp2.gameObject.SetActive(false);
            Kalp3.gameObject.SetActive(false);
        }

    }

    IEnumerator SoruBasýnaSure()
    {
        while (sure != 0)
        {
            sure--;
            yield return new WaitForSeconds(1f);
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
        geriyeSaymaText.text = "START";
        yield return new WaitForSeconds(0.5f);
        geriyeSaymaText.text = "";

        Toplama.SetActive(true);
        Sik1Text.enabled = true;
        Sik2Text.enabled = true;
        SayacText.enabled = true;
        CanText.enabled = true;
        SureText.SetActive(true);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        SoruPaneli.SetActive(true);
        SoruÜret();
    }

    IEnumerator TextiSilme()
    {
        yield return new WaitForSeconds(1f);
        TebriklerText.text = "";
    }
}