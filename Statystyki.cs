using UnityEngine;

public class Statystyki : MonoBehaviour {

    public static int monety;
    public int funduszeStartowe = 500;

    public static int zdrowie;
    public int zdrowieStartowe = 100;

    public static int fale;
    public static int kills;

    void Start ()
    {
        monety = funduszeStartowe;
        zdrowie = zdrowieStartowe;
        fale = 0;
        kills = 0;
    }
}
