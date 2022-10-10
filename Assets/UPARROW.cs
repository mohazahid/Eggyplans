using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UPARROW : MonoBehaviour
{
    public GameObject prefab;
    bool kPressed = false;
    public double Timer = .2;
    private int eCount = 0;
    private int pCount = 0;

    [SerializeField] Vector3 _axis = Vector3.forward;
    private int speed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }
    public TMP_Text Eg;
    public TMP_Text pd;
    // Update is called once per frame
    void Update()
    {
        Eg.text = "Eggs on Screen " + EggCount();
        pd.text = "Planes destoryed (Hero) " + pCount;
        if (Input.GetKey("space"))
        {
            Timer -= 1 * Time.deltaTime;
            if (Timer <= 0)
            {
                Instantiate(prefab, transform.position + (transform.forward * 2), transform.rotation);
                eCount += 1;
                Timer = .2f;
            }
        }
        if (kPressed)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (!kPressed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
        if (Input.GetKeyDown("m"))
        {
            kPressed = kPressed ? false : true;
        }
        if (Input.GetKey("d") && kPressed)
        {
            transform.Rotate(_axis.normalized * -45f * Time.deltaTime);
        }
        if (Input.GetKey("a") && kPressed)
        {
            transform.Rotate(_axis.normalized * 45f * Time.deltaTime);
        }
        if (Input.GetKey("w") && kPressed)
        {
            speed += 1;
        }
        if (Input.GetKey("s") && kPressed)
        {
            if (speed != 0)
            {
                speed -= 1;
            }
        }
        if (Input.GetKeyDown("q"))
        {
            Application.Quit();
        }
    }
    int EggCount()
    {
        GameObject[] pln = GameObject.FindGameObjectsWithTag("Egg");
        int count = pln.Length;
        return count;
    }
    int PlaneDesHero(int value)
    {
        Debug.Log(pCount);
        return pCount += value;
    }

}