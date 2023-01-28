using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6.0f;

    void Start()
    {
        transform.Rotate(0, 0, 0);
    }

    Vector3 lastPositon;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;

    void Update()
    {


        var Horiz = Input.GetAxis("Horizontal");
        var Vert = Input.GetAxis("Vertical");

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        var f = transform.forward;
        var r = transform.right;

        var cameraview = transform.rotation;
        transform.Rotate(-v, h, 0);

        transform.position += (f * Vert + r*Horiz) * speed * Time.deltaTime;
        
        
    }
}
