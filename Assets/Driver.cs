using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float steerSpeed = 1;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f; 

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0); 
        
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Slow Bump")
        {
            Debug.Log("Oops! Slowing down.");
            moveSpeed = slowSpeed; 
        } else if (collision.tag == "Speed Bump")
        {
            Debug.Log("Nice! Speeding Up!");
            moveSpeed = boostSpeed; 
        } else if (collision.tag == "Customer")
        {
            Debug.Log("Package Delivered! Speed reset.");
            moveSpeed = 20f; 
        }
    }
}
