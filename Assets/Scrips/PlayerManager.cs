using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playerVisual;
    [SerializeField] GameObject playerManager;

    public event EventHandler PlayerHitground;
    public static PlayerManager instance;

    Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        rb = playerManager.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            PlayerHitground?.Invoke(this, EventArgs.Empty);
            this.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
}
