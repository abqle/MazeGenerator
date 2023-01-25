using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    Vector3 lastPositon;


    void Update()
    {


        var currentPosition = Input.mousePosition;
        var deltaPositon = currentPosition - lastPositon;
        lastPositon = currentPosition;

        var Hh = Input.GetAxis("Horizontal");
        var vv = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(Hh, 0, vv) * speed * Time.deltaTime;
        transform.Rotate(new Vector3(deltaPositon.y, deltaPositon.x, 0), Space.World);
        // transform.rotation = new Quaternion(mousex, 1, mousey, 1);
    }
}
