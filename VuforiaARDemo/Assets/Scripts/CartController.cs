using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartController : MonoBehaviour
{
    private string cartProductName;
    public TextMeshPro cartCount;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, Time.deltaTime * 50);
        if (CartState.cartItems.ContainsKey(cartProductName)){
            cartCount.text = CartState.cartItems[cartProductName].ToString();
        }else
        {
            cartCount.text = "0";
        }
    }

    public string GetCartItem(){
        return cartProductName;
    }

    public void SetCartName(string prodName){
        cartProductName = prodName;
    }
}
