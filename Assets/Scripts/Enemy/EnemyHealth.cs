using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    private float currentHP;
    private float maxHP = 4;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
            Destroy(gameObject);
        }
    }
}
