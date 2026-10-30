// Allandryo santos 2.2

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover3D_Inertia : MonoBehaviour
{
    [Header("Configuració de Moviment")]
    [SerializeField] private float speed = 8f;
    [Range(0.01f, 1f)]
    [SerializeField] private float inertiaFactor = 0.1f;

    private Rigidbody rb;
    private Vector3 inputDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Llegim l'entrada del jugador a Update
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Calculem la velocitat desitjada mantenint la gravetat actual en l'eix Y
        Vector3 targetVel = new Vector3(inputDirection.x * speed, rb.linearVelocity.y, inputDirection.z * speed);

        // Apliquem la interpolació lineal (Lerp) per crear l'efecte d'inèrcia en arrencar i frenar
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVel, inertiaFactor);
    }
}