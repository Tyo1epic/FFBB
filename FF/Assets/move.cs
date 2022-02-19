using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") == 1){
    GetComponent<Rigidbody>().AddForce(new Vector3(0 , 10, 0));
        }
        transform.position += (Camera.main.transform.forward * 5 * Time.deltaTime) * Input.GetAxis("Vertical");
    }
}