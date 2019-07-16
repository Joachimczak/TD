using UnityEngine;

public class Punkty : MonoBehaviour {

    public static Transform[] punkty;

    void Awake()
    {
        punkty = new Transform[transform.childCount];

        for (int i = 0; i < punkty.Length; i++)
        {
           punkty[i] = transform.GetChild(i);
        }
    }
}
