using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float speed = 1;

    // Update is called once per frame
    void Update()
    {
        Moving();

        UIManager.Instance.UpdateScore(transform.position.y);
    }

    private void Moving()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (horizontal < 0) 
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (transform.position.x < -3)
        {
            transform.position += Vector3.right * 6;
        }
        else if (transform.position.x > 3)
        {
            transform.position += Vector3.left * 6;
        }
    }

    private void Jumping()
    {
        if (rb.velocity.y <= 0)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 400);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            Jumping();
        }
        if (collision.CompareTag("DeathZone"))
        {
            //Lose
            UIManager.Instance.FinishGame();
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Finish"))
        {
            //win
            UIManager.Instance.FinishGame();
            gameObject.SetActive(false);
        }
    }

    internal void SavePoint()
    {
        throw new NotImplementedException();
    }
}
