//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody {get; private set;}
    
    public float speed = 10f;

    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }
    
    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidBody.velocity = Vector2.zero;
        

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(1f, 1f);
        force.y = -1f;

        this.rigidBody.AddForce(force.normalized * this.speed);
    }

    //private void FixedUpdate()
    //{
    //    this.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * speed;
    //}



}
