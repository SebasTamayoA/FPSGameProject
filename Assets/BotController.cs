using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movimiento del bot
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement) * movementSpeed;
        rb.velocity = movement;

        // Rotación del bot
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookAtPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAtPoint);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Colisión con otro objeto
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Lógica de colisión con obstáculo
            Vector3 reflectDirection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflectDirection;
        }
    }
}