using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] public float movementSpeed = 10;
    [SerializeField] private int scoreAmount;
    [SerializeField] private bool isNegative;

    private void Update()
    {
        transform.position += -transform.forward * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            GameManager.instance.ChangeScore(scoreAmount);
            if (isNegative)
            {
                GameManager.instance.ChangeScore(-scoreAmount);
            }
            Debug.Log(scoreAmount);
            Destroy(gameObject);
        }
    }
}
