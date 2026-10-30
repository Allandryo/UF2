

using UnityEngine;

public class CoinByName : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    void Update()
    {
        // Fa girar la moneda sobre el seu propi eix Y a velocitat constant
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Detecció comparant el nom del GameObject
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Moneda recollida (detectada per nom)!");
            Destroy(gameObject);
        }
    }
}