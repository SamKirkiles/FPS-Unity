using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    public float movementSpeed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // returns a value between -1 and 1 depending on if a or d is pressed down
        float vertical = Input.GetAxis("Vertical"); // returns a value between -1 and 1 depending on if w or s is pressed down

        rb.AddRelativeForce(horizontal * Time.deltaTime * movementSpeed, 0, vertical * Time.deltaTime * movementSpeed);
    }

    void LateUpdate()
    {
        // Horizontal Look
        float mouse_horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * 100;
        gameObject.transform.Rotate(0, mouse_horizontal, 0);


    }

}
