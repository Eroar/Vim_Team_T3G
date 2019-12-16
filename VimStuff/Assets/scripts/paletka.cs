using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class paletka : MonoBehaviour
{
    public float maxAxis;
    private Transform Pos;
    private Rigidbody rigidbody;
    private Vector3 zeroPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Pos = gameObject.GetComponent<Transform>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        zeroPoint = Pos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rigidbody.AddForce(new Vector3(-speed,0,0));
            //Debug.Log("addingForce");
        }
        if (Input.GetKey("d"))
        {
            rigidbody.AddForce(new Vector3(speed,0,0));
            //Debug.Log("addingForce");
        }
        Vector3 dist = Pos.position - zeroPoint;
        if (dist.magnitude > maxAxis)
        {
            if (dist.x > zeroPoint.x)
            {
                Pos.position = new Vector3(zeroPoint.x + maxAxis, Pos.position.y, Pos.position.z);
            }
            if (dist.x < zeroPoint.x)
            {
                Pos.position = new Vector3(zeroPoint.x - maxAxis, Pos.position.y, Pos.position.z);
            }
            //Debug.Log("Limiter");


        }
        Pos.position.Set(Pos.position.x, zeroPoint.y, zeroPoint.z);
    }
}
