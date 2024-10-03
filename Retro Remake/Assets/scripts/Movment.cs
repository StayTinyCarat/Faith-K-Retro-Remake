using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movment : MonoBehaviour
{

    public Projectile laserPrefab;

    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, jump = KeyCode.Z;

    public float speed = 10, jumpHeight = 15;

    private bool _laserActive;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKey() is for HOLDING a key
        // Input.GetKeyDown() is for PRESSING a key
        // Input.GetKeyUp() is for RELEASING a key

        if (Input.GetKey(left)) // Check for the player HOLDING DOWN the left button
        {
            // Get the GameObject's Rigidbody2D component and set its velocity to the left at the given speed
            _rb.velocity = Vector2.left * speed;
        }

        if (Input.GetKey(right)) // Check for the player HOLDING DOWN the right button
        {
            // Get the GameObject's Rigidbody2D component and set its velocity to the right at the given speed
            _rb.velocity = Vector2.right * speed;
        }

        if (Input.GetKey(up)) // Check for the player HOLDING DOWN the up button
        {
            // Get the GameObject's Rigidbody2D component and set its velocity to the up at the given speed
            _rb.velocity = Vector2.up * speed;
        }

        if (Input.GetKey(down)) // Check for the player HOLDING DOWN the down button
        {
            // Get the GameObject's Rigidbody2D component and set its velocity to the down at the given speed
            _rb.velocity = Vector2.down * speed;
        }


        if (Input.GetKey(jump)) // Check for the player PRESSING the jump button
        {
            // Get the GameObject's Rigidbody2D component and set its velocity to the down at the given jump height
            _rb.velocity = Vector2.up * jumpHeight;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }

    }

    private void Shoot()
    {
        if (!_laserActive)
        { 
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }    
   
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

}
