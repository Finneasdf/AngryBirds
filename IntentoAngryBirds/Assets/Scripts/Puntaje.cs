using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public static Puntaje instancia;
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoTiros;
    public GameObject pantallaGanaste;
    public GameObject pantallaPerdiste; 
    public int tirosDisponibles = 5; 
    private int puntaje = 0;
    private int totalCerditos;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        totalCerditos = FindObjectsByType<Cerdito>(FindObjectsSortMode.None).Length;
        pantallaGanaste.SetActive(false);
        pantallaPerdiste.SetActive(false);
        ActualizarTextoTiros();
    }

    public void AgregarPunto()
    {
        puntaje++;
        textoPuntaje.text = "Puntos: " + puntaje;

        if (puntaje >= totalCerditos)
        {
            pantallaGanaste.SetActive(true);
        }
    }

    public void UsarTiro()
    {
        tirosDisponibles--;
        ActualizarTextoTiros();

        
        if (tirosDisponibles <= 0 && puntaje < totalCerditos)
        {
            pantallaPerdiste.SetActive(true);
        }
    }

    private void ActualizarTextoTiros()
    {
        textoTiros.text = "Pájaros: " + tirosDisponibles;
    }
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}