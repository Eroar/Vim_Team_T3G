using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] GameObject pball;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    GameObject createBall(Vector2 pos)
    {
        GameObject g;
        g = Instantiate(pball);
        g.transform.localPosition = pos;
        g.transform.SetParent(this.transform);
        return g;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
