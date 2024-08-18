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
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Invoke("ReStartGame", 1);
        }
    }

    private void ReStartGame()
    {
        this.transform.position = new Vector3(-200, 0, 0);
        playerVisual.GetComponent<SpriteRenderer>().enabled = true;
        playerVisual.GetComponent<TrailRenderer>().enabled = true;
        this.GetComponent<EdgeCollider2D>().enabled = true;
        rb.constraints = RigidbodyConstraints2D.None;
    }
}