using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Importar para usar UI
using UnityEngine.SceneManagement;  // Importar para cambiar de escena

public class Reloj : MonoBehaviour
{
    float segundos;
    public int minutos;
    public int velocidaddeltiempo;

    private bool corriendo;  // Bandera para saber si el cron�metro est� corriendo

    // A�ade esta variable para el texto
    public Text tiempoText;  // Referencia al componente Text en el Canvas

    void Start()
    {
        corriendo = true;  // Iniciar el cron�metro cuando comienza la escena
        segundos = 0;
        minutos = 0;
        ModificarTextoDelTiempo();  // Aseg�rate de que el texto inicie correctamente
    }

    void Update()
    {
        if (corriendo)
        {
            segundos += Time.deltaTime * velocidaddeltiempo;

            ModificarTextoDelTiempo();

            if (segundos >= 60)
            {
                minutos += 1;
                segundos = 0;
            }

            if (minutos == 60)
            {
                minutos = 0;
            }
        }
    }

    void ModificarTextoDelTiempo()
    {
        // Actualiza el texto en la interfaz con el tiempo actual
        tiempoText.text = AgregarUnCeroAdelanteSiEsNecesario(minutos) + ":" +
                          AgregarUnCeroAdelanteSiEsNecesario(Mathf.FloorToInt(segundos));

        // Solo para depuraci�n, si deseas ver el tiempo en la consola
        Debug.Log("Tiempo actual: " + tiempoText.text);
    }

    public string AgregarUnCeroAdelanteSiEsNecesario(int n)
    {
        if (n < 10) return "0" + n.ToString();
        else return n.ToString();
    }

    // M�todo para detener el cron�metro cuando se complete una vuelta
    public void CompletarVuelta()
    {
        corriendo = false;  // Detenemos el cron�metro
        GuardarScore();  // Guardamos el tiempo final como score
        CambiarEscena();  // Cambiamos de escena
    }

    // Guarda el tiempo final como score en una variable est�tica
    void GuardarScore()
    {
        ScoreManager.tiempoFinal = minutos * 60 + Mathf.FloorToInt(segundos);  // Guardamos el tiempo total en segundos
        Debug.Log("Tiempo final guardado: " + ScoreManager.tiempoFinal);
    }

    // M�todo para cambiar de escena cuando se completa la vuelta
    void CambiarEscena()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Finish");  // Cambia el nombre por la escena deseada
    }

    // M�todo para detectar cuando el jugador cruza la l�nea de meta
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            CompletarVuelta();  // Llamamos a la funci�n para completar la vuelta
        }
    }
}
