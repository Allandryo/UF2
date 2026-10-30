// Allandryo santos 2.4

using UnityEngine;

public class CoinByTag : MonoBehaviour
{

    [SerializeField] private float speed = 100f;

    void Update()
    {
        // Fa girar la moneda sobre el seu propi eix Y a velocitat constant
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
    /*
     * QUINA ÉS MILLOR I PER QUÈ?
     * La Versió B (other.CompareTag("Player")) és molt millor per tres motius:
     * 1. Rendiment: CompareTag està optimitzat internament per Unity i no genera brossa a la memòria (Garbage Collection) com sí que fan les comparacions de cadenes de text (strings).
     * 2. Flexibilitat i escalabilitat: Si instanciem el jugador des d'un Prefab, Unity li canviarà el nom a "Player(Clone)" i la Versió A fallarà. Amb Tags funciona sempre.
     * 3. Seguretat: Si escrivim un Tag que no existeix a Project Settings, CompareTag ens avisa amb un error a la consola, mentre que comparar per nom simplement no farà res i costarà més de depurar.
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moneda recollida (detectada per CompareTag)!");
            Destroy(gameObject);
        }
    }
}