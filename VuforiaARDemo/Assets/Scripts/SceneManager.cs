using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    private string productName;
    public TextMeshPro productTitle, productPrice;
    public CartController cart;

    // Start is called before the first frame update
    void Start()
    {
        //The Parent GameObject name should = Product name in Product Details.cs
        productName = transform.parent.name;

        //Get the Product Details from The static class ProductDetail.cs
        ProductDetail.GetProductDetails(productName);
        productTitle.text = ProductDetail.name;
        productPrice.text = ProductDetail.price;
        
        cart.SetCartName(productName);
    }
}
