using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float speed = 80f;
    [SerializeField] private float damage = 2f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 5f)
;    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damage);
        }
    }
}
