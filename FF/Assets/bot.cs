using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public Transform player;
    public Transform lastplayer;
    public bool hey;
    public int speed = 1;
    public int norm_speed = 1;
    public int agg_speed = 1;
    public float rote = 0;
    public Transform touching;
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
        if(hey == true){
        directions = lastplayer.position - transform.GetChild(0).position;
        rotations = Quaternion.LookRotation(directions);
        transform.rotation = Quaternion.Euler(new Vector3(rote, 0, 0));
        transform.rotation = Quaternion.Euler(rotation.eulerAngles + transform.rotation.eulerAngles);
        transform.GetChild(0).rotation = rotations;
        }else{        
        transform.rotation = Quaternion.Euler(new Vector3(rote, 0, 0));
        transform.rotation = Quaternion.Euler(rotation.eulerAngles + transform.rotation.eulerAngles);
        transform.GetChild(0).rotation = rotations;
        }

        transform.position += (transform.forward * 2 * Time.deltaTime) * speed;
        if(Mathf.Floor(player.position.y - transform.position.y) >= 2){
            GameObject[] res = GameObject.FindGameObjectsWithTag("stairs");
            bool heyd = false;
            for (int e = 0; e < res.Length; e++)
            {
                if(res[e] == touching){
heyd = true;
                }
            }
            if(!heyd){
            player = res[Random.Range(0, res.Length)].transform.GetChild(0);
            hey = true;}
        }
        if(direction.x < 0.3f && direction.y < 0.3f && direction.z < 0.3f && hey == true){
player = lastplayer;
hey = false;
        }
        if(Physics.Raycast(lookWall, out hit, 3)){
            if(hit.collider.tag == "wwall" || hit.collider.tag == "stair"){
                if(hit.collider.transform.childCount > 0){
player = hit.collider.transform.GetChild(0);
hey = true;
                }
            }
        }
        bool heehee = true;
        for (int i = 1; i < 5; i++)
        {
                  RaycastHit hits;
        Ray lookWalls = new Ray(transform.position, transform.forward);
                    if(Physics.Raycast(lookWalls, out hits, i)){
            if(hits.collider.tag == "wwall"){
heehee = false;
break;
            }
        }
        }
        if(heehee == true){
            speed = agg_speed;
        }else{
speed = norm_speed;
        }
    }
    void OnCollisionEnter(Collision other){
    rote = other.gameObject.transform.rotation.x;
touching = other.gameObject.transform;
    }
}
