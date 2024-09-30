using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCar; // Referencia al carro del jugador
    public float distance = 6.0f; // Distancia detrás del carro
    public float height = 3.0f; // Altura de la cámara sobre el carro
    public float followSpeed = 10.0f; // Velocidad con la que la cámara sigue al carro
    public float rotationSpeed = 5.0f; // Velocidad de rotación para seguir al carro
    public float tiltAngle = 15.0f; // Ángulo de inclinación de la cámara

    void LateUpdate()
    {
        // Posición deseada detrás y arriba del carro
        Vector3 desiredPosition = playerCar.position - playerCar.forward * distance + Vector3.up * height;
        
        // Movimiento suave hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Mantén la rotación de la cámara solo en el eje Y
        Vector3 lookDirection = playerCar.position - transform.position;
        lookDirection.y = 0; // Elimina la rotación en el eje vertical para evitar problemas al girar

        // Rotación suave para seguir al carro
        Quaternion desiredRotation = Quaternion.LookRotation(lookDirection);
        
        // Añadir inclinación en el eje X sin afectar la rotación Y del coche
        desiredRotation *= Quaternion.Euler(tiltAngle, 0, 0);

        // Aplicar rotación suave
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
