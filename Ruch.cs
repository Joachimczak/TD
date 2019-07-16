using UnityEngine;

[RequireComponent(typeof(Przeciwnicy))]
public class Ruch : MonoBehaviour {

    private Transform cel;
    private int nrpunktu = 0;
    private Przeciwnicy przeciwnik;

    void Start()
    {
        przeciwnik = GetComponent<Przeciwnicy>();
        cel = Punkty.punkty[0];
    }

    void Update()
    {
        Vector3 kierunek = cel.position - transform.position;
        transform.Translate(kierunek.normalized * przeciwnik.szybkosc * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, cel.position) <= 0.5f)
        {
            KolejnyPunkt();
        }
        przeciwnik.szybkosc = przeciwnik.szybkoscPodstawowa;
    }

    void KolejnyPunkt()
    {
        if (nrpunktu >= Punkty.punkty.Length - 1)
        {
            Meta();
            return;
        }
        nrpunktu++;
        cel = Punkty.punkty[nrpunktu];
    }

    void Meta()
    {
        Statystyki.zdrowie = Statystyki.zdrowie - 5;
        
        Destroy(gameObject);

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


