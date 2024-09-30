using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedCamera : MonoBehaviour
{
    public Transform playerCamera;  // La c�mara que sigue al carro
    public float duration = 10f;    // Duraci�n del efecto de c�mara invertida

    private Quaternion originalRotation;
    public GameObject children;

    private void Start()
    {
        // Guardamos la rotaci�n original de la c�mara
        originalRotation = playerCamera.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(InvertCamera());
            children.SetActive(false);
        }
    }

    private IEnumerator InvertCamera()
    {
        // Invertimos la c�mara rot�ndola 180 grados en el eje Z
        playerCamera.rotation = originalRotation * Quaternion.Euler(0, 0, 180);

        // Esperamos el tiempo definido
        yield return new WaitForSeconds(duration);

        // Restauramos la rotaci�n original de la c�mara
        playerCamera.rotation = originalRotation;
    }
}
