using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float distancePerEdge;
    private Vector3 movementDirection;
    private float movingDownBeganY;
    private float movingDownFinishY;
    private int xDirection;
    private bool movingDown;

    void Start()
    {
        movingDown = false;
        xDirection = -1;
        movementDirection.Set(-1, 0, 0);
    }

    private void FixedUpdate()
    {
        Transform transform = gameObject.GetComponent<Transform>();
        transform.Translate(movementDirection*movementSpeed);

        if(((transform.position.x <= leftBound) || (transform.position.x >= rightBound)) && (!movingDown))
        {
            movingDown = true;
            movingDownBeganY = transform.position.y;
            movingDownFinishY = movingDownBeganY - distancePerEdge;
            //Set to move down
            movementDirection.Set(0, -1, 0);
            xDirection = -xDirection;
        }
        
        if(transform.position.y <= movingDownFinishY)
        {
            movingDown = false;
            movementDirection = new Vector3(xDirection*1, 0, 0);
        }
    }
}
