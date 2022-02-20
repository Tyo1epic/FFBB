using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public bool jump = true;
    public float speed = 1;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") == 1 && jump == true){
   // GetComponent<Rigidbody>().AddForce(new Vector3(0 , 200, 0));
    jump = false; 
        }
                if(Input.GetKey(KeyCode.LeftShift)){
speed = 2f;
        }else{
speed = 1;
        }
        transform.position += ((Camera.main.transform.forward * 5 * Time.deltaTime) * Input.GetAxis("Vertical")) * speed;
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "floor"){
jump = true;
        }
    }
}