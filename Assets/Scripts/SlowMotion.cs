using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowMotionFactor = 0.5f; // Factor de cámara lenta (0.5 es la mitad de velocidad)
    public float duration = 10f;          // Duración del efecto de cámara lenta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(ActivateSlowMotion());
        }
    }

    private IEnumerator ActivateSlowMotion()
    {
        // Activar cámara lenta
        Time.timeScale = slowMotionFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; // Ajustar la física para que funcione correctamente con el nuevo timeScale

        // Esperar el tiempo que dura la cámara lenta
        yield return new WaitForSecondsRealtime(duration);  // Usamos WaitForSecondsRealtime para que no se vea afectado por el timeScale

        // Restaurar el timeScale a la velocidad normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;  // Restaurar el tiempo fijo de física a su valor original
    }
}
