using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    public Transform transforms;
    void Update()
    {
        if (transform != null) {
            transform.rotation = Quaternion.Euler( new Vector3 (0, Input.mousePosition.x, 0));
            Camera.main.transform.rotation = Quaternion.Euler( new Vector3 (-Mathf.Lerp (-90, 90, Mathf.InverseLerp (0, Screen.height, Input.mousePosition.y)),  Input.mousePosition.x, 0));
        }
    }
}
