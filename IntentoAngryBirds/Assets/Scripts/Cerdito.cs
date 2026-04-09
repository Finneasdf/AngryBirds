using UnityEngine;

public class Cerdito : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isPajarito = collision.gameObject.GetComponent<Pajarito>();
        if (isPajarito)
        {
            Destroy(gameObject);
            Puntaje.instancia.AgregarPunto();
        }

        float golpeCaja = -0.5f;
        bool isGolpe = collision.contacts[0].normal.y < golpeCaja;

        if (isGolpe)
        {
            Destroy(gameObject);
            Puntaje.instancia.AgregarPunto();
        }
    }
}
