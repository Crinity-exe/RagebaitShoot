using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float speed;
    Vector3 moveDirection;

    private void Update()
    {
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) && transform.position.x > -7)
        {
            moveDirection += -transform.right;
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 7)
        {
            moveDirection += transform.right;
        }
        Move();
    }

    private void Move()
    {
        moveDirection.Normalize();
        Vector3 targetVelocity = moveDirection * speed;
        playerRB.linearVelocity = new Vector3(moveDirection.x * speed, playerRB.linearVelocity.y, moveDirection.z * speed);
    }
}
