using UnityEngine;

public class Budowanie : MonoBehaviour {

    private Turrety turretDoZbudowania;
    private Platforma wybranaPlatforma;
    public static Budowanie instancja;
    public PlatformaUI platformaUI;
    
    void Awake()
    {
        instancja = this;
    }

    public bool JestMiejsce { get { return turretDoZbudowania != null; } }
    public bool JestKasa { get { return Statystyki.monety >= turretDoZbudowania.cena; } }

    public void WybierzTurretDoZbudowania(Turrety turret)
    {
        turretDoZbudowania = turret;
        Odznacz();
    }

    public Turrety GetTurretDoZbudowania()
    {
        return turretDoZbudowania;
    }

    public void WybierzPlatforme(Platforma plat)
    {
        if (wybranaPlatforma == plat)
        {
            Odznacz();
            return;
        }
        wybranaPlatforma = plat;
        turretDoZbudowania = null;
        platformaUI.Wybierz(plat);
    }

    public void Odznacz()
    {
        wybranaPlatforma = null;
        platformaUI.Off();
    }
}


