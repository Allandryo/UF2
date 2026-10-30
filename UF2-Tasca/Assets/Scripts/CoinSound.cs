// Allandryo santos 2.6

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinSound : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private Collider coinCollider;


    [SerializeField] private float speed = 100f;

    void Update()
    {
        // Fa girar la moneda sobre el seu propi eix Y a velocitat constant
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        coinCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Reproduïm el so
            audioSource.Play();

            // 2. Desactivem la vista i el collider perquè sembli que ja ha desaparegut i no es pugui agafar 2 cops
            if (meshRenderer != null) meshRenderer.enabled = false;
            if (coinCollider != null) coinCollider.enabled = false;

            // 3. Destruïm l'objecte un cop hagi acabat de sonar el clip d'àudio
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}