using System.Collections;
using UnityEngine;

public class InvertedControls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("Entró en Trigger con " + other.name);
            PrometeoCarController carController = other.GetComponent<PrometeoCarController>();

            if (carController != null)
            {
                Debug.Log("Encontró el controlador de coche, iniciando inversión.");
                StartCoroutine(ApplyInvertedControls(carController));

                GetComponent<Collider>().enabled = false; 
                GetComponent<Renderer>().enabled = false; 
            }
            else
            {
                Debug.Log("No se encontró el controlador de coche en el objeto.");
            }
        }
    }

    private IEnumerator ApplyInvertedControls(PrometeoCarController carController)
    {
        carController.InvertControls(); // Invertir controles
        Debug.Log("Controles invertidos en el coche.");

        yield return new WaitForSeconds(15); // Esperar 5 segundos

        carController.ResetControls(); // Restaurar controles
        Debug.Log("Controles restaurados en el coche.");
    }
}
