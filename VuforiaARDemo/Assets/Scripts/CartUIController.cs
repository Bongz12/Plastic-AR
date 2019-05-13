using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartUIController : MonoBehaviour
{
    private RectTransform rectTransform;
    public  RectTransform productListRectTransform;
    public ScrollRect scrollRect;
    private Vector3 uiPosition;

    // Start is called before the first frame update
    void Start()
    {        
        gameObject.SetActive(false);
        rectTransform = GetComponent<RectTransform>();
        DefaultPosition();
    }

    // Update is called once per frame
    void Update()
    {
        LimitScrolling();
    }

    private void LimitScrolling(){
        float scrollUpLimit = (CartState.cartItems.Count * 200f) + 50f;
        
        uiPosition = gameObject.transform.localPosition;

        if(gameObject.transform.localPosition.y > scrollUpLimit){
            scrollRect.inertia = false;
            
            uiPosition.y = scrollUpLimit;
            gameObject.transform.localPosition  = uiPosition;
        }       
        else if(gameObject.transform.localPosition.y < (-150f)){
            scrollRect.inertia = false;
            DefaultPosition();
        }
        else{            
            scrollRect.inertia = true;
        }
    }

    private void DefaultPosition(){
         uiPosition.y = -130f;
         gameObject.transform.localPosition  = uiPosition;
    }

    public void ShowCart() {
         if(gameObject.activeSelf) {
             gameObject.SetActive(false);
         }
         else {
             DefaultPosition();
             gameObject.SetActive(true);
         }
     }
}
