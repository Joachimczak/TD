using UnityEngine;
using UnityEngine.EventSystems;

public class Platforma : MonoBehaviour {

    public Vector3 pozycja;
    public GameObject turret;
    public Turrety szablon;
    public bool czyUlepszony = false;
    private Renderer rend;
    private Color kolorStartowy;
    public Color nowyKolor;
    public Color czerwonyKolor;
    Budowanie budowanie;

    public Vector3 GetPozycjaBudowania()
    {
        return transform.position + pozycja;
    }

    void Start()
    {
        budowanie = Budowanie.instancja;

        rend = GetComponent<Renderer>();
        kolorStartowy = rend.material.color;
    }

    void Zbuduj(Turrety sz)
    {
        if (Statystyki.monety < sz.cena)
        {
            return;
        }

        Statystyki.monety -= sz.cena;

        GameObject t = (GameObject)Instantiate(sz.prefab, GetPozycjaBudowania(), Quaternion.identity);
        turret = t;

        szablon = sz;
    }

    public void Ulepsz()
    {
        if (Statystyki.monety < szablon.kosztUlepszenia)
        {
            return;
        }

        Statystyki.monety -= szablon.kosztUlepszenia;

        Destroy(turret);

        GameObject t = (GameObject)Instantiate(szablon.ulepszeniePrefab, GetPozycjaBudowania(), Quaternion.identity);
        turret = t;

        czyUlepszony = true;
    }

    public void Sprzedaj()
    {
        Statystyki.monety += 50;
        Destroy(turret);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!budowanie.JestMiejsce)
        {
            return;
        }

        if (!budowanie.JestKasa)
        {
            rend.material.color = nowyKolor;
        }
        else
        {
            rend.material.color = czerwonyKolor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = kolorStartowy;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            budowanie.WybierzPlatforme(this);
            return;
        }

        if (!budowanie.JestMiejsce)
        {
            return;
        }

        Zbuduj(budowanie.GetTurretDoZbudowania());
    }
}
