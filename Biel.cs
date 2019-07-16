using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Biel : MonoBehaviour {

    public Image img;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo (string scena)
    {
        StartCoroutine(FadeOut(scena));
    }

    IEnumerator FadeIn()
    {
        float czas = 1f;
        while (czas > 0f)
        {
            czas -= Time.deltaTime;
            img.color = new Color(1f, 1f, 1f, czas);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scena)
    {
        float czas = 0f;
        while (czas < 1f)
        {
            czas += Time.deltaTime;
            img.color = new Color(1f, 1f, 1f, czas);
            yield return 0;
        }
        SceneManager.LoadScene(scena);
    }
}
