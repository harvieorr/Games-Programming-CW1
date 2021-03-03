using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public GameManager gameManager;
    // Declare Speed
    public float speed = 12f;
    // Declare Gravity
    public float gravity = -9.81f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Declare Jump Height
    public float jumpHeight = 3f;

    // Set Max Health as 100
    public int maxHealth = 100;
    
    public int currentHealth;

    public HealthBar healthBar;

    Vector3 velocity;
    // On ground or not
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
       // Set current health to max on start
        currentHealth = maxHealth;
      // Set Health bar to max on start
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly check if you're on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(25);
        }

        if (currentHealth == 0)
        {
            gameManager.EndGame();
        }


    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
}
    


