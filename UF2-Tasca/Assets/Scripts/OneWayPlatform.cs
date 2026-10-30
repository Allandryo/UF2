// Allandryo santos 2.5

using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] private Collider playerCollider;
    private Collider platformCollider;

    void Awake()
    {
        platformCollider = GetComponent<Collider>();
    }

    void Start()
    {
        // Si no s'ha assignat manualment a l'Inspector, busquem el jugador pel seu Tag
        if (playerCollider == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                playerCollider = playerObj.GetComponent<Collider>();
        }
    }

    void Update()
    {
        if (playerCollider == null) return;

        // Comparem la part més baixa del jugador (bounds.min.y) amb la part més alta de la plataforma (bounds.max.y)
        bool playerIsAbove = playerCollider.bounds.min.y >= platformCollider.bounds.max.y - 0.05f;

        // Si el jugador està per sota (!playerIsAbove), ignorem la col·lisió (true).
        // Si està per sobre, activem la col·lisió (ignore = false) perquè pugui trepitjar-la.
        Physics.IgnoreCollision(platformCollider, playerCollider, !playerIsAbove);
    }
}