using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ChaMovment))]
public class Hunter : MonoBehaviour
{
    private int health = 20;
    
    [SerializeField]
    private ChaMovment _movment;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
    }
    public 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HealthReduce(10);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ReduceSpeed(true);
        }
    }
    
    private void OnValidate()
    {
        if (!_movment) TryGetComponent(out _movment);
    }

    void HealthReduce(int damage )
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            Death();
        }
    }

    public void ReduceSpeed(bool slowdown)
    {
        if (slowdown)
        {
            _movment.speed = 0;
        }
    }
    
    private void Death()
    {
        Destroy(gameObject);
    }
}
