using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    private Image image;
    private float fade = 1f;
    private float difference = 0.5f;

    void Start(){
        image = gameObject.GetComponent<Image>();
    }

    void OnEnable()
    {
       fade = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        fade -= difference * Time.deltaTime;
        if(fade < 0){
            gameObject.SetActive(false);
        }
        
        var tempColor = image.color;
        tempColor.a = fade;
        image.color = tempColor; 
    }
}
