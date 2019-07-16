using UnityEngine;

public class Pocisk : MonoBehaviour {

    private Transform cel;
    public float szybkosc = 70f;
    public float eksplozja = 0f;
    public int uszkodzenia = 50;
    public GameObject efektPocisku;

    public void Szukaj(Transform _cel)
    {
        cel = _cel;
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(cel == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 kierunek = cel.position - transform.position;
        float czasKlatki = szybkosc * Time.deltaTime;

        if (kierunek.magnitude <= czasKlatki)
        {
            Trafiony();
            return;
        }

        transform.Translate(kierunek.normalized * czasKlatki, Space.World);
        transform.LookAt(cel);
	}

    void Trafiony()
    {
        GameObject efekt = (GameObject)Instantiate(efektPocisku, transform.position, transform.rotation);
        Destroy(efekt, 5f);

        if(eksplozja > 0f)
        {
            Wybuch();
        }
        else
        {
            Uszkodzenia(cel);
        }
        Destroy(gameObject);
    }

    void Uszkodzenia(Transform minion)
    {

        Przeciwnicy m = minion.GetComponent<Przeciwnicy>();

        //Tu moge wstawić zabezpiecznie przed nieśmiertelnymi

        m.OtrzymajUszkodzenia(uszkodzenia);

    }

    void Wybuch()
    {
        Collider[] kolizje = Physics.OverlapSphere(transform.position, eksplozja);

        foreach (Collider kolizja in kolizje)
        {
            if(kolizja.tag=="Minion")
            {
                Uszkodzenia(kolizja.transform);
            }
        }
    }
}
