using UnityEngine;
using UnityEngine.UI;

public class Przeciwnicy : MonoBehaviour {

    public float szybkoscPodstawowa = 10f;
    public float szybkosc;
    public float startoweZdrowiePrzeciwnika = 100f;
    private float zdrowiePrzeciwnika;
    public int nagroda = 50;
    public GameObject efektZgonu;
    public Image pasekZdrowia;

    void Start()
    {
        szybkosc = szybkoscPodstawowa;
        zdrowiePrzeciwnika = startoweZdrowiePrzeciwnika;
    }

    public void OtrzymajUszkodzenia(float ilosc)
    {
        zdrowiePrzeciwnika -= ilosc;

        pasekZdrowia.fillAmount = zdrowiePrzeciwnika / startoweZdrowiePrzeciwnika;

        if (zdrowiePrzeciwnika <=0)
        {
            Umrzyj();
        }
    }

    public void Spowolnienie(float spowolnienie)
    {
        szybkosc = szybkoscPodstawowa * (1f - spowolnienie);
    }

    void Umrzyj()
    {
        Statystyki.monety += nagroda;
        GameObject efekt = (GameObject)Instantiate(efektZgonu, transform.position, Quaternion.identity);
        Destroy(efekt, 5f);
        Destroy(gameObject);
        Statystyki.kills++;
        if (Fale.pozostaliPrzeciwnicy > 0)
        {
            Fale.pozostaliPrzeciwnicy--;
        }
        if (Fale.pozostaliPrzeciwnicy < 0)
        {
            Fale.pozostaliPrzeciwnicy = 0;
        }
    }
}




