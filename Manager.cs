using UnityEngine;

public class Manager : MonoBehaviour {

    public static bool koniecGry;
    private bool pauza = false;

    public GameObject gameover;

	void Start()
    {
        koniecGry = false;
    }

	void Update ()
    {
        if (koniecGry)
            return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Koniec();

        if (Statystyki.zdrowie <= 0 )
            Koniec();      
	}

    void Koniec()
    {
        koniecGry = true;
        gameover.SetActive(true);
    }

    public void Pauza()
    {
        if (!pauza)
        {
            Time.timeScale = 0f;
            pauza = true;
        }
        else
        {
            Time.timeScale = 1f;
            pauza = false;
        }  
    }
}

