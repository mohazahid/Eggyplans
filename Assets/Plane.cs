using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    int Health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "GreenUp") {
            Debug.Log("Hit"); 
            Destroy(gameObject);
        }
        if(col.gameObject.name == "Egg") {
            Debug.Log("Hit"); 
            Health -=25;
            if (Health == 0) {
               Destroy(col.gameObject); 
               Destroy(gameObject);
            }
        }
    }
}
