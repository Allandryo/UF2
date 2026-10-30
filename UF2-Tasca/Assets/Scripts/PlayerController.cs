//Allandryo santos T2.3

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;

    void Awake()
    {
        // Segur que no serà null gràcies a RequireComponent
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vel = new Vector3(h * moveSpeed, rb.linearVelocity.y, v * moveSpeed);
        rb.linearVelocity = vel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}