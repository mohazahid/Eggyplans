using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Contorl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    private int desPlane = 0;
    private int amount = 10;
    public TMP_Text allPlanes;
    void Start()
    {
        for (var i = 0; i < amount; i++)
        {
            spawn();
        }
    }
    void spawn()
    {
        Vector3 randomizePosition = new Vector3(Random.Range(-145, 145), Random.Range(-90, 90), 0);
        Instantiate(prefab, randomizePosition, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject[] pln = GameObject.FindGameObjectsWithTag("Enemy");
        int count = pln.Length;
        allPlanes.text = "All Planes destoryed " + desPlane;
        while (count < 10)
        {
            spawn();
            desPlane++;
            count++;
        }
        
    }

}
