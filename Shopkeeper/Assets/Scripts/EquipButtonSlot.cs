using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButtonSlot : MonoBehaviour
{
    [SerializeField] Image myImage;
    public Button myButton;

    private void Start()
    {
        myButton = GetComponent<Button>();
    }
    public void SetSelected(bool select)
    {
        myImage.gameObject.SetActive(select);
    }
}
