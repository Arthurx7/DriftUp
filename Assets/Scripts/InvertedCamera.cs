using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedCamera : MonoBehaviour
{
    public Transform playerCamera;  // La cámara que sigue al carro
    public float duration = 10f;    // Duración del efecto de cámara invertida

    private Quaternion originalRotation;

    private void Start()
    {
        // Guardamos la rotación original de la cámara
        originalRotation = playerCamera.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(InvertCamera());
        }
    }

    private IEnumerator InvertCamera()
    {
        // Invertimos la cámara rotándola 180 grados en el eje Z
        playerCamera.rotation = originalRotation * Quaternion.Euler(0, 0, 180);

        // Esperamos el tiempo definido
        yield return new WaitForSeconds(duration);

        // Restauramos la rotación original de la cámara
        playerCamera.rotation = originalRotation;
    }
}
