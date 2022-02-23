using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public bool jump = true;
    public float speed = 1;
    public Animator inter;
    void Start()
    {
        Cursor.visible = false;
        GameObject.Find("Cube/so").GetComponent<AudioSource>().Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") == 1 && inter != null){
   // GetComponent<Rigidbody>().AddForce(new Vector3(0 , 200, 0));
   inter.Play("dooropen");
        }
                if(Input.GetKey(KeyCode.LeftShift)){
                    Camera.main.fieldOfView = 80;
speed = 3f;
        }else{
                    Camera.main.fieldOfView = 60;
speed = 1;
        }
        Vector3 direc = ((((Camera.main.transform.forward * 5 * Time.deltaTime) * Input.GetAxis("Vertical")) * 100 * speed) + (((Camera.main.transform.right * 5 * Time.deltaTime) * Input.GetAxis("Horizontal")) * 100 * speed));
    GetComponent<Rigidbody>().velocity = new Vector3(direc.x,  GetComponent<Rigidbody>().velocity.y, direc.z);
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "floor"){
jump = true;
        }
    }
        void OnTriggerEnter(Collider other){
        if(other.name == "live_fr"){
             GameObject.Find("run").GetComponent<Animator>().SetTrigger("start_running");
                GameObject.Find("chase").GetComponent<AudioSource>().Play(0);      
            for (int i = 0; i <  GameObject.Find("froggy").transform.childCount; i++)
            {
          GameObject.Find("froggy").transform.GetChild(i).GetComponent<bot>().startUp = true;  
          GameObject.Find("froggy").transform.GetChild(i).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;   
          GameObject.Find("froggy").transform.GetChild(i).GetComponent<Animator>().enabled = false;      
            }

        }else if(other.tag == "interarct"){

inter = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
        }
    }
            void OnTriggerExit(Collider other){
if(other.tag == "interarct"){

inter = null;
        }
    }
}