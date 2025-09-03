using UnityEngine;
using UnityEngine.Rendering;
using UnityEngineInternal;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float damage = 3;

    private void Update()
    {
        transform.position += -transform.forward * moveSpeed * Time.deltaTime;
    }    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
