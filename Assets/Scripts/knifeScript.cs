﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            gameController.Instance.gameUI.DecrementDisplayedKnideCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;

        isActive = false;

        if(collision.collider.tag == "Log")
        {
            GetComponent<ParticleSystem>().Play();

            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);

            gameController.Instance.OnSuccessfulKnifeHit();
        }
        else if(collision.collider.tag == "Knife")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            gameController.Instance.StartGameOverSequence(false);
        }
    }
}
