using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Fale : MonoBehaviour {

    public Text timer;
    public static int pozostaliPrzeciwnicy = 0;
    private int numerFali = 0;
    private float odliczanie = 2f;
    public Transform punktStartowy;
    public float czasDoFali = 5f;
    public Fala[] fale;

    void Update()
    {
        if(pozostaliPrzeciwnicy > 0)
            return;
        
        else if (odliczanie <= 0f)
        {
            StartCoroutine(DodajFale());
            odliczanie = czasDoFali;
            return;
        }
        odliczanie -= Time.deltaTime;
        odliczanie = Mathf.Clamp(odliczanie, 0f, Mathf.Infinity);
        timer.text = string.Format("{0:00.00}",odliczanie);
    }

    IEnumerator DodajFale()
    {
        Statystyki.fale++;

        Fala fala = fale[numerFali];

        for (int i = 0; i < fala.liczba; i++)
        {
            DodajPrzeciwnika(fala.przeciwnik);
            yield return new WaitForSeconds(1f / fala.spacja);
        }
        numerFali++;

        if (numerFali == fale.Length)
            this.enabled = false;
    }

    void DodajPrzeciwnika(GameObject przeciwnik)
    {
        Instantiate(przeciwnik, punktStartowy.position, punktStartowy.rotation);
        pozostaliPrzeciwnicy++;
    }
}
