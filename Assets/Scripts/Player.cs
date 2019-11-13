using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(inputH, 0, inputV);
        rb.AddForce(direction * speed);
    }
}
