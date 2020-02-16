using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontal;
    public float vertical;
    public float walkSpeed;
    public float mouseSensitivity;
    private float speed;
    private Rigidbody rb;
    public int jumpForce;
    public Transform camera1;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        bool grounded = (Physics.Raycast(transform.position, Vector3.down, 1f, 1 << LayerMask.NameToLayer("Ground"))); // Checks for ground beneeth you
        horizontal = Input.GetAxis("Horizontal"); // horizontal input
        vertical = Input.GetAxis("Vertical"); // vertical input
        rb.MovePosition(transform.position + (transform.forward * vertical * speed) + (transform.right * horizontal * speed)); // move the player
        
      

        if (Input.GetKey(KeyCode.LeftShift) && grounded == true) // sprinting
        {
            speed = walkSpeed * 2;
        }
        else
        {
            speed = walkSpeed;
        }


        if (grounded == true && Input.GetButtonDown("Fire1")) // jumping
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        // rb.velocity += transform.forward * vertical * speed;
        // rb.velocity += transform.right * horizontal * speed;
     
        
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime); // mouse x movement
        camera1.transform.Rotate(-Vector3.right * Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime); // mouse y movement

       

    }
}
