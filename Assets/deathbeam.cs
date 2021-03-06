﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbeam : MonoBehaviour
{
    [SerializeField] GameObject parLeft;

    [SerializeField] GameObject parRight;

    [SerializeField] GameObject explosionEfx;
    [SerializeField] GameObject explosionEfxGreen;
    [SerializeField] GameObject explosionEfxOrange;

    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var castLeft = Physics2D.Raycast(transform.position, Vector2.left);
        var castRight = Physics2D.Raycast(transform.position, Vector2.right);
        parLeft.transform.position = castLeft.point;
        parRight.transform.position = castRight.point;

        sr.color = new Color(Random.Range(0.9f, 1.0f), Random.Range(0.0f, 0.1f), 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            Instantiate(explosionEfx, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Shield"))
        {
            Instantiate(explosionEfxGreen, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        } else if (other.CompareTag("Shell"))
        {
            Instantiate(explosionEfxOrange, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Instantiate(explosionEfx, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            cameraMovement.move = false;
            scoreManager.EndGame();
        } else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}