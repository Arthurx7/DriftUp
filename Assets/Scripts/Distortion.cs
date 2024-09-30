using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Distortion : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private LensDistortion lensDistortion;
    public float distortionIntensity = 50f;  // Ajusta la intensidad de la distorsión
    public float duration = 10f;
    public float xMultiplier = 0.464f;
    public float yMultiplier = 0.706f;
    public float xCenter = -1f;
    public float yCenter = -0.08f;

    private void Start()
    {
        // Asegúrate de que el PostProcessVolume tenga el componente LensDistortion
        postProcessVolume.profile.TryGetSettings(out lensDistortion);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(ActivateDistortion());
            Destroy(gameObject);
        }
    }

    private IEnumerator ActivateDistortion()
    {
        // Activa el efecto de distorsión
        lensDistortion.intensity.value = distortionIntensity;
        lensDistortion.intensityX.value = xMultiplier;
        lensDistortion.intensityY.value = yMultiplier;
        lensDistortion.centerX.value = xCenter;
        lensDistortion.centerY.value = yCenter;

        // Espera durante 'duration' segundos
        yield return new WaitForSeconds(duration);

        // Desactiva el efecto de distorsión
        lensDistortion.intensity.value = 0f;
        lensDistortion.intensityX.value = 1f;
        lensDistortion.intensityY.value = 1f;
        lensDistortion.centerX.value = 0f;
        lensDistortion.centerY.value = 0f;
    }
}
