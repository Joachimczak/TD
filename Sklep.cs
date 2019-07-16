using UnityEngine;

public class Sklep : MonoBehaviour {


    public Turrety standardowy;
    public Turrety wyrzutnia;
    public Turrety laser;
    Budowanie budowanie;

    void Start()
    {
        budowanie = Budowanie.instancja;
    }

    public void WybierzTurret()
    {
        Debug.Log("Kupiono");
        budowanie.WybierzTurretDoZbudowania(standardowy);
    }

    public void WybierzWyrzutnie()
    {
        Debug.Log("Kupiono");
        budowanie.WybierzTurretDoZbudowania(wyrzutnia);
    }

    public void WybierzLaser()
    {
        Debug.Log("Kupiono");
        budowanie.WybierzTurretDoZbudowania(laser);
    }
}
