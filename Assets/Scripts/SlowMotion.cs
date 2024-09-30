using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowMotionFactor = 0.5f; // Factor de c�mara lenta (0.5 es la mitad de velocidad)
    public float duration = 10f;          // Duraci�n del efecto de c�mara lenta
    public GameObject children;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(ActivateSlowMotion());
            children.SetActive(false);
        }
    }

    private IEnumerator ActivateSlowMotion()
    {
        // Activar c�mara lenta
        Time.timeScale = slowMotionFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; // Ajustar la f�sica para que funcione correctamente con el nuevo timeScale

        // Esperar el tiempo que dura la c�mara lenta
        yield return new WaitForSecondsRealtime(duration);  // Usamos WaitForSecondsRealtime para que no se vea afectado por el timeScale

        // Restaurar el timeScale a la velocidad normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;  // Restaurar el tiempo fijo de f�sica a su valor original
    }
}
