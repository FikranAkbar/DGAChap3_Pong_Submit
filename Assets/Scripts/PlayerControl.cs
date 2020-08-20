using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton;
    public KeyCode downButton;
    public float speed;
    public float yBoundary;
    private Rigidbody2D rb2d;
    private int score;
    private ContactPoint2D lastContactPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb2d.velocity;
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0;
        }
        rb2d.velocity = velocity;


        Vector3 position = transform.position;
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    public int Score
    {
        get { return score; }
    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
