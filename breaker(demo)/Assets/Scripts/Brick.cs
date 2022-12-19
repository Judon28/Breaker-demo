using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer SR { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }
    public bool unbreakable;
    public int points = 100;

    private void Awake()
    {
        this.SR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
        if (!unbreakable)
        {
            this.health = this.states.Length;
            this.SR.sprite = this.states[this.health - 1];
        } 
    }

    //public void ResetBrick()
    //{
    //    this.gameObject.SetActive(true);
    //}

    private void Hit()
    {
        if (this.unbreakable)
        {
            return;
        }
        
        this.health--;

        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
           this.SR.sprite = this.states[this.health - 1]; 
        }

        FindObjectOfType<GameManager>().Hit(this);
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }

}
