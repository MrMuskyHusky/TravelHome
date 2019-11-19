using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        // Make the player move left or right.
        float inputH = Input.GetAxis("Horizontal");
        // Make the player move forward or backwards
        float inputV = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(inputH, 0, inputV);
        // Add force to the player while moving with speed.
        rb.AddForce(direction * speed);
    }
}
