using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TouchManager : MonoBehaviour
{
    public GameObject starExplosion;
    private ParticleSystem particleSystem;
    public GameObject itemPrefab;
    public GameObject itemContainer;
    private VideoPlayer _videoPlayer;

    void Start(){
        particleSystem = starExplosion.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {        
        //Check if the user touches the screen
        TouchedSceneObject();
        
    }

    private void TouchedSceneObject(){
        
        if(Input.GetMouseButtonDown(0))
        {            
            Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);            
            
            Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

            RaycastHit hit;
            if(Physics.Raycast(mousePosN, mousePosF-mousePosN, out hit))
            {
                if(hit.collider.gameObject.name == "Shopping_Cart"){
                    CartTouched(hit);
                }
                else if(hit.collider.gameObject.name == "VideoPlayer"){
                    VideoTouched(hit);
                }
            }
        }
    }

    private void CartTouched(RaycastHit hit){        
        CartController cartController = hit.transform.gameObject.GetComponent<CartController>();
        AddItemToCart(cartController.GetCartItem());
        
        starExplosion.transform.position = hit.transform.gameObject.transform.position;
        particleSystem.Stop();
        particleSystem.Play();
    }
    
    private void AddItemToCart(string prodName){
        if (CartState.cartItems.ContainsKey(prodName)){
            CartState.cartItems[prodName]++;
        }else
        {
            CartState.cartItems.Add(prodName, 1);
            Instantiate(itemPrefab, itemContainer.transform).GetComponent<ItemController>().SetItemDetails(prodName);
        }
    }

    private void VideoTouched(RaycastHit hit){
        Debug.Log("Video Touched");        
        _videoPlayer = hit.transform.gameObject.GetComponent<VideoPlayer>();
        
        if(_videoPlayer.isPlaying)
        {
           _videoPlayer.Pause();
        }else{
           _videoPlayer.Play();
        }
    }
}
