using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    int Health = 100;
    void Start()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a -= 0.1f;
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }


    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "GreenUp")
        {
            Debug.Log("Hit");
            col.gameObject.SendMessage("PlaneDesHero", 1);
            Destroy(gameObject);
        }
        else
        {
            Health -= 25;
            GetComponent<Renderer>().material.SetAlpha(GetComponent<Renderer>().material.color.a - .1F);
            Destroy(col.gameObject);
            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
public static class ExtensionMethods
{


    public static void SetAlpha(this Material material, float value)
    {
        Color color = material.color;
        color.a = value;
        material.color = color;
    }


}