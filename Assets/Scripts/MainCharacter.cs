using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public float jumpForce = 600f;
    public float movementSpeed = 5;
    public GameObject[] lifePoints = new GameObject[3];
    public int health = 3;

    private bool isDead = false; // Collision death
    private Rigidbody2D rb2d;
    private bool isTouchingGround;
    private bool damageTaken = false;
    private float immunityTimer = 2f;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (isDead == false) {
            if (Input.GetKeyDown("space") && isTouchingGround == true) {
                rb2d.AddForce(new Vector2(0, jumpForce)); 
            } else if (Input.GetKey("right")) {
                transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
            } else if (Input.GetKey("left")) {
                transform.Translate(-movementSpeed * Time.deltaTime,0 ,0);
            }
        }
        if (damageTaken == true) {
            Debug.Log(immunityTimer);
            immunityTimer -= Time.deltaTime;
            if (immunityTimer <= 0) {
                damageTaken = false;
                immunityTimer = 2f;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        for (int i = 0; i < collision.contactCount; i++) {
            if (collision.gameObject.tag == "Ground") {
                isTouchingGround = true;
            } else if (collision.gameObject.tag == "Enemy") {
                if (collision.GetContact(i).normal.y > 0) {
                    rb2d.AddForce(new Vector2(0, jumpForce / 2));
                } else if (damageTaken == false) {
                    Debug.Log(collision.gameObject.tag);
                    damageTaken = true;
                    health--;
                    Debug.Log(health);
                }
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision) {
        isTouchingGround = false;
    }
}
