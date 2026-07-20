using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    public float moveDirection = 1f;

    public float moveSpeed = 2f;

    public Transform startPoint;
    public Transform endPoint;

    public Vector3 currentPos;

    private void Update()
    {
        //get cur
        currentPos = transform.position;

        currentPos.x += moveSpeed * Time.deltaTime * moveDirection;
        transform.position = currentPos;

        if (transform.position.x > endPoint.position.x)
        {
            moveDirection = -1f;
        } 
        if (transform.position.x < startPoint.position.x)
        {
            moveDirection = 1f;
        }
    }
}
