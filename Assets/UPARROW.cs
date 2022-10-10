using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPARROW : MonoBehaviour
{
    public GameObject prefab;
    bool kPressed = false;
    [SerializeField] Vector3 _axis = Vector3.forward;
    private int speed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown("space")) {
            Instantiate(prefab, transform.position+(transform.forward*2), transform.rotation);
        }
        if(kPressed) {
            transform.Translate( Vector3.up* speed * Time.deltaTime);
        }
        if (!kPressed) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
        if(Input.GetKeyDown("k")) {
            kPressed = kPressed ? false : true;
        }
        if(Input.GetKey("d") &&  kPressed) {
            transform.Rotate( _axis.normalized * -45f * Time.deltaTime );
        }
        if(Input.GetKey("a") &&  kPressed) {
            transform.Rotate( _axis.normalized * 45f * Time.deltaTime );
        }
        if(Input.GetKey("w") &&  kPressed) {
            speed += 1;
        }
        if(Input.GetKey("s") &&  kPressed) {
            if(speed != 0) {
              speed -= 1;  
            }
        }
    }
}