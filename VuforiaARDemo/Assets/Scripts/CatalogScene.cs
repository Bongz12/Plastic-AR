using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatalogScene : MonoBehaviour
{
    public float radius = 0.05f;
    public int productCount = 8;
    public Texture2D[] indexImages;
    public GameObject indexPrefab;
    public string[] headerTxt;
    public string[] pageTxt;
    
    void Start()
    {
        for (int i = 0; i < productCount; i++)
        {
            float angle = i * Mathf.PI*2f / productCount;
            Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, 0f, Mathf.Sin(angle)*radius);

            GameObject prefab = Instantiate(indexPrefab, gameObject.transform);     

            //set the index 
            GameObject quad = prefab.transform.GetChild(0).gameObject;
            Texture2D myTexture = indexImages[i];
            quad.GetComponent<Renderer>().material.mainTexture = myTexture;

            
            GameObject header = prefab.transform.GetChild(1).gameObject;
            header.GetComponent<TextMeshPro>().text = headerTxt[i];
            GameObject page = prefab.transform.GetChild(2).gameObject;
            page.GetComponent<TextMeshPro>().text = pageTxt[i];
                   
            prefab.transform.localPosition = newPos;
        }
    }
}
