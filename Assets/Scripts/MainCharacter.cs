using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public float jumpForce = 500f;
    public float movementSpeed = 5;

    private bool isDead = false; // Collision death
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (isDead == false) {
            if (Input.GetKeyDown("space")) {
                rb2d.AddForce(new Vector2(0, jumpForce));
            } else if (Input.GetKey("right")) {
                transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
            } else if (Input.GetKey("left")) {
                transform.Translate(-movementSpeed * Time.deltaTime,0 ,0);
            }
        }
    }
}
