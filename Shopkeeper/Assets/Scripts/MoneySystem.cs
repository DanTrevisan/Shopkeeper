using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public TextMeshProUGUI textGold;

    private void Update()
    {
        //Not the proper way to do this, if I had more time I'd change it.
        textGold.text = GameManager.CurrentGold.ToString();
    }
}
