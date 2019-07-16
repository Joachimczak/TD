using UnityEngine;
using UnityEngine.UI;

public class ZdrowieUI : MonoBehaviour {

    public Text zdrowieText;
	
	void Update ()
    {
        zdrowieText.text = "Zdrowie: " + Statystyki.zdrowie + "%";
	}
}
