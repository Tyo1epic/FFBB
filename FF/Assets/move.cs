using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move : MonoBehaviour 
{
    public bool jump = true;
    public float speed = 1;
    public Slider moveS;
    public Animator inter;
    bool ag;
    void Start()
    {
        Cursor.visible = false;
        GameObject.Find("Cube/so").GetComponent<AudioSource>().Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") == 1 && inter != null)
        {
            // GetComponent<Rigidbody>().AddForce(new Vector3(0 , 200, 0));
            inter.Play("dooropen");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ag = true;
            if (speed == 2)
            {
                Camera.main.GetComponent<Animator>().Play("out", 0, 0); 
            }
            moveS.value -= moveS.maxValue * 0.001f;
            if (moveS.value < moveS.maxValue / 2)
            {
                speed = (moveS.value / moveS.maxValue) * 8;
            }
            else {
                speed = 4f;
            }
        }
        else
        {
            StartCoroutine(reload());
            if (ag)
            {
                Camera.main.GetComponent<Animator>().Play("in", 0, 0);
                ag = false;
            }
            speed = 2;
        }
        Vector3 direc = ((((Camera.main.transform.forward * 5) * Input.GetAxis("Vertical")) * speed) + (((Camera.main.transform.right * 5) * Input.GetAxis("Horizontal")) * speed));
        GetComponent<Rigidbody>().velocity = new Vector3(direc.x, GetComponent<Rigidbody>().velocity.y, direc.z);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            jump = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "live_fr")
        {
            if(GameObject.Find("chase")){
            GameObject.Find("run").GetComponent<Animator>().SetTrigger("start_running");
            GameObject.Find("chase").GetComponent<AudioSource>().Play(0);}
            for (int i = 0; i < GameObject.Find("froggy").transform.childCount; i++)
            {
                GameObject.Find("froggy").transform.GetChild(i).GetComponent<bot>().startUp = true;
                GameObject.Find("froggy").transform.GetChild(i).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameObject.Find("froggy").transform.GetChild(i).GetComponent<Animator>().enabled = false;
            }

        }
        else if (other.tag == "interarct")
        {

            inter = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
        }else if (other.tag == "go")
        {

           SceneManager.LoadSceneAsync(other.name);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "interarct")
        {

            inter = null;
        }


    }
    public IEnumerator reload()
    {
        yield return new WaitForSeconds(1f);
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            for (float i = moveS.value; i < moveS.maxValue; i += moveS.maxValue * 0.0008f)
            {

                moveS.value = i;
                yield return null;
                   if (Input.GetKey(KeyCode.LeftShift)) break;
        
            }
        }
    }
}