using UnityEngine;

public class RuchKamery : MonoBehaviour {

    private bool ruszaj = true;
    public float minimum = 15f;
    public float maksimum = 70f;
    public float szybkoscScrolla = 3f;
    public float szybkosc = 20f;
    public float kraniecEkranu = 100f;

	void Update () {

        if (Manager.koniecGry)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            ruszaj = !ruszaj;

        if (!ruszaj)
            return;

        if (Input.GetKey("w"))
            transform.Translate(Vector3.forward * szybkosc * Time.deltaTime, Space.World);

        if (Input.GetKey("s"))
            transform.Translate(Vector3.back * szybkosc * Time.deltaTime, Space.World);

        if (Input.GetKey("d"))
            transform.Translate(Vector3.right * szybkosc * Time.deltaTime, Space.World);

        if (Input.GetKey("a"))
            transform.Translate(Vector3.left * szybkosc * Time.deltaTime, Space.World);
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pozycja = transform.position;

        pozycja.y -= scroll * 1000 * szybkoscScrolla * Time.deltaTime;
        pozycja.y = Mathf.Clamp(pozycja.y, minimum, maksimum);
        transform.position = pozycja;
    }
}
