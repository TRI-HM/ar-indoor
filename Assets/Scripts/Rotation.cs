using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 20.0f;
    public GameObject gameObject;
    public GameObject gameObject2;
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, speed * Time.deltaTime);
        gameObject2.transform.Rotate(Vector3.up, speed * Time.deltaTime);
        gameObject2.transform.Rotate(Vector3.left, speed * Time.deltaTime);
    }
}
