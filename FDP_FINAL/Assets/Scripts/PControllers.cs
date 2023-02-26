using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PControllers : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody rb;
    public bool isGrounded = true;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontal, 0, vertical);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
    }

}
}
