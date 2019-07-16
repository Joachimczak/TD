using UnityEngine;
using UnityEngine.UI;

public class Monety : MonoBehaviour {

    public Text monetyText;

	void Update ()
    {
        monetyText.text = "$" + Statystyki.monety.ToString();
	}
}
