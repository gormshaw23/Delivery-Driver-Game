using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 hasNotPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelayTime = 0.5f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked up package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor; 
            Destroy(other.gameObject, destroyDelayTime);
            
             
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Another day another dollar!");
            hasPackage = false;
            spriteRenderer.color = hasNotPackageColor;
        }
    
    }
}
