using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]  public ShopInventory lastInventoryCollider;
    [SerializeField] private CanvasGroup ButtonCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shop") && collision.gameObject.transform.parent.GetComponent<ShopInventory>() != null)
        {
            lastInventoryCollider = collision.gameObject.transform.parent.GetComponent<ShopInventory>();
            ButtonCanvas.alpha = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shop") && collision.gameObject.transform.parent.GetComponent<ShopInventory>() != null)
        {
            lastInventoryCollider = null;
            ButtonCanvas.alpha = 0;

        }
    }

}
