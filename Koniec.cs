using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Koniec : MonoBehaviour {

    public Text fale;
    public Text kills;
    public Biel biel;
    public string menu = "Menu";

    void OnEnable()
    {
        fale.text = Statystyki.fale.ToString();
        kills.text = Statystyki.kills.ToString();
    }

    public void JeszczeRaz()
    {
        biel.FadeTo(SceneManager.GetActiveScene().name);
        Fale.pozostaliPrzeciwnicy = 0;
    }

    public void Wyjscie()
    {
        biel.FadeTo(menu);
    }
}
