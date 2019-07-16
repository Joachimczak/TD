using UnityEngine;
using UnityEngine.UI;

public class PlatformaUI : MonoBehaviour {

    private Platforma cel;
    public GameObject ui;
    public Text kosztUl;
    public Button ulepsz;

    public void Wybierz(Platforma plat)
    {
        cel = plat;
        transform.position = cel.GetPozycjaBudowania();
        ui.SetActive(true);

        if (!cel.czyUlepszony)
        {
            kosztUl.text = "$" + cel.szablon.kosztUlepszenia;
            ulepsz.interactable = true;
        }
        else
        {
            kosztUl.text = "MAX";
            ulepsz.interactable = false;
        }  
    }

    public void Off()
    {
        ui.SetActive(false);
    }

    public void Ulepszenie()
    {
        cel.Ulepsz();
        Budowanie.instancja.Odznacz();
    }

    public void Sprzedanie()
    {
        cel.Sprzedaj();
        Budowanie.instancja.Odznacz();
    }
}



