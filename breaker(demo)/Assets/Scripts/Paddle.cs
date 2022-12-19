using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rigidBody;
    private Vector3 direction;
    private float moveSpeed = 30f;

    public Vector2 direct { get; private set; }

    public float maxBounceAngle = 75f;

    // Use this for initialization
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rigidBody.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                rigidBody.velocity = Vector2.zero;
        }

        //movement for keyboard
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direct = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direct = Vector2.right;
        }
        else
        {
            this.direct = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (this.direct != Vector2.zero)
        {
            this.rigidBody.AddForce(this.direct * this.moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;

            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody>().velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidBody.velocity = rotation * Vector2.up * ball.rigidBody.velocity.magnitude;

        }

    }
}
