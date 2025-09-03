using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public event UnityAction WhenDead;


    [SerializeField] public float currentHP;
    [SerializeField] private float maxHP = 60f;

    private void Awake()
    {
        instance = this;
    }
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
            WhenDead?.Invoke(); 
            Destroy(gameObject);
            Debug.Log("ded");
        }
        Debug.Log(currentHP);
    }
}
