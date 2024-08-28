using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpeedSO speedData;
    Rigidbody2D rb;
    Vector2 speedVelocity = Vector2.right;
    

    public event EventHandler MouseClikEnable;
    public event EventHandler MouseClickDisable;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        MouseClickMovement();
    }


    private void Movement()
    {
        rb.velocity = speedVelocity * speedData.speed;
    }

    private void MouseClickMovement()
    {
        if (Input.GetMouseButton(0))
        {
            speedVelocity = new Vector2(1, 1).normalized;
            MouseClikEnable?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            speedVelocity = new Vector2(1, -1).normalized;
            MouseClickDisable?.Invoke(this, EventArgs.Empty);
        }
    }
}
