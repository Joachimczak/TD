using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform cel;
    private Przeciwnicy przeciwnik;
    public float zasieg = 15f;
    public float strzelanie = 1f;
    private float wstrzymajOgien = 0f;
    public bool laser = false;
    public int DOT = 30;
    public LineRenderer lineRenderer;
    public float spowolnienie = .3f;
    public string minionTag = "Minion";
    public Transform obracanie;
    public float szybkosc = 5f; //obracania
    public GameObject pociskPrefab;
    public Transform punktPocisku;

	void Start ()
    {
        InvokeRepeating("AktualizujCel", 0f, 0.5f);
	}

	void Update ()
    {
        if (cel==null)
        {
            if (laser)
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            return;
        }
        Celuj();

        if (laser)
            Laser();
        else
        {
            if (wstrzymajOgien <= 0)
            {
                Strzal();
                wstrzymajOgien = 1f / strzelanie;
            }
            wstrzymajOgien -= Time.deltaTime;
        }
    }

    void Celuj()
    {
        Vector3 kierunek = cel.position - transform.position;
        Quaternion kierunekObrotu = Quaternion.LookRotation(kierunek);
        Vector3 obrot = Quaternion.Lerp(obracanie.rotation, kierunekObrotu, Time.deltaTime * szybkosc).eulerAngles;
        obracanie.rotation = Quaternion.Euler(0f, obrot.y, 0f);
    }

    void Strzal()
    {
        GameObject pociskGO = (GameObject)Instantiate(pociskPrefab, punktPocisku.position, punktPocisku.rotation);
        Pocisk pocisk = pociskGO.GetComponent<Pocisk>();

        if (pocisk != null)
        {
            pocisk.Szukaj(cel);
        }
    }

    void Laser()
    {
        przeciwnik.OtrzymajUszkodzenia(DOT * Time.deltaTime);
        przeciwnik.Spowolnienie(spowolnienie);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, punktPocisku.position);
        lineRenderer.SetPosition(1, cel.position);
    }

    void AktualizujCel()
    {
        GameObject[] minions = GameObject.FindGameObjectsWithTag(minionTag);
        float najkrotszyDystans = Mathf.Infinity;
        GameObject najblizszyMinion = null;

        foreach (GameObject minion in minions)
        {
            float odlegloscDoMiniona = Vector3.Distance(transform.position, minion.transform.position);

            if (odlegloscDoMiniona < najkrotszyDystans )
            {
                najkrotszyDystans = odlegloscDoMiniona;
                najblizszyMinion = minion;
            }
        }

        if (najblizszyMinion != null && najkrotszyDystans <= zasieg)
        {
            cel = najblizszyMinion.transform;
            przeciwnik = najblizszyMinion.GetComponent<Przeciwnicy>();
        }
        else
        {
            cel = null;
        }
    }
}
