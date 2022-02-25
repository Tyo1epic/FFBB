using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public bool jump = true;
    public float speed = 1;
    public Slider moveS;
    public Animator inter;
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
            StopCoroutine(reload());
            if (speed == 2)
            {
                Camera.main.GetComponent<Animator>().Play("out", 0, 0);
            }
            moveS.value -= 0.005f;
            if (moveS.value < moveS.maxValue / 2)
            {
                speed = moveS.value;
            }
            else {
                speed = 4f;
            }
        }
        else
        {
            StartCoroutine(reload());
            if (speed == 3)
            {
                Camera.main.GetComponent<Animator>().Play("in", 0, 0);
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
            GameObject.Find("run").GetComponent<Animator>().SetTrigger("start_running");
            GameObject.Find("chase").GetComponent<AudioSource>().Play(0);
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
            for (float i = moveS.value; i < moveS.maxValue; i += 0.1f)
            {

                moveS.value = i;
                yield return null;
            }
        }
    }
}