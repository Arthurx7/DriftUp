using UnityEngine;
using UnityEngine.UI;

public class MostrarScore : MonoBehaviour
{
    public Text scoreText;  // Referencia al componente Text en el Canvas

    void Start()
    {
        // Convertir el tiempo final a formato minutos:segundos
        int totalSegundos = Mathf.FloorToInt(ScoreManager.tiempoFinal);
        int minutos = totalSegundos / 60;
        int segundos = totalSegundos % 60;

        // Actualizar el texto con el score
        scoreText.text = "Score: " + AgregarUnCeroAdelanteSiEsNecesario(minutos) + ":" +
                         AgregarUnCeroAdelanteSiEsNecesario(segundos);
    }

    public string AgregarUnCeroAdelanteSiEsNecesario(int n)
    {
        if (n < 10) return "0" + n.ToString();
        else return n.ToString();
    }
}
