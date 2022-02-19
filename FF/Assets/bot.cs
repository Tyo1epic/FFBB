using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray lookWall = new Ray(transform.position, transform.forward);
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.position += (transform.forward * 2 * Time.deltaTime);
        if(Physics.Raycast(lookWall, out hit, 3)){
            Debug.Log(hit);
        }
    }
}
