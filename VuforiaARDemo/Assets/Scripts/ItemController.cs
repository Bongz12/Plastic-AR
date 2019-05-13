using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{    
    public TextMeshProUGUI productName;
    public TextMeshProUGUI prodPrice;
    public TextMeshProUGUI quantityAmount;
    private string itemName = "";

    public void SetItemDetails(string prodName){  
        itemName = prodName;
        ProductDetail.GetProductDetails(prodName);    
        productName.text = ProductDetail.name.ToString();
        prodPrice.text = ProductDetail.price.ToString();
        quantityAmount.text = CartState.cartItems[prodName].ToString();
    }

    
    void Update(){  
        quantityAmount.text = CartState.cartItems[itemName].ToString();
    }
}
