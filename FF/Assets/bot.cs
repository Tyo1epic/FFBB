using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public Transform player;
    public Transform lastplayer;
    public bool hey;
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
        Vector3 directions = player.position - transform.GetChild(0).position;
        Quaternion rotations = Quaternion.LookRotation(directions);
        transform.rotation = rotation;
        transform.GetChild(0).rotation = rotations;
        transform.position += (transform.forward * 2 * Time.deltaTime);
        if(direction.x < 0.3f && direction.y < 0.3f && direction.z < 0.3f && hey == true){
player = lastplayer;
        }
        if(Physics.Raycast(lookWall, out hit, 3)){
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "wwall"){
                if(hit.collider.transform.childCount > 0){
player = hit.collider.transform.GetChild(0);
hey = true;
                }
            }
        }
    }
}