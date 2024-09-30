using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    public GameObject objetoAActivar;  // El objeto que ser� activado/desactivado
    public Collider colliderAActivar;

    // M�todo que se ejecuta cuando algo entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))  // Verifica si el objeto que entra es el jugador
        {
            objetoAActivar.SetActive(true);
            colliderAActivar.enabled = true;
        }
    }

    
}
