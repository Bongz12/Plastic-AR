using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderComplete : MonoBehaviour
{
    public GameObject itemContainer;
    public GameObject greenTick;
    public CartUIController cartContainer;

    public void CompleteOrder(){
        CartState.cartItems.Clear();
        foreach (Transform child in itemContainer.transform) {
            GameObject.Destroy(child.gameObject);
        }

        greenTick.SetActive(true);
        cartContainer.ShowCart();
    }
}
