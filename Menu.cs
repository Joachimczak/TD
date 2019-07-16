using UnityEngine;

public class Menu : MonoBehaviour {

    public string poziom = "LEVEL1";

    public Biel biel;

    public void Zagraj()
    {
        biel.FadeTo(poziom);
    }

    public void Wyjdz()
    {
        Application.Quit();
    }
}
