using UnityEngine;


public class Pajarito : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Vector3 posicionInicial, limitePosicion;

    public float force;
    public float maxDis;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        posicionInicial = transform.position;
    }

    private void OnMouseDrag()
    {
        
        Vector3 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        dragPosition.z = transform.position.z;
        limitePosicion = dragPosition;

        float dragDis = Vector3.Distance(posicionInicial , dragPosition);

        if(dragDis > maxDis)
        {
            limitePosicion = posicionInicial + (dragPosition - posicionInicial).normalized * maxDis;
        }

        transform.position = limitePosicion;

    }

    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Vector3 throwVector = posicionInicial - limitePosicion;
        rb.AddForce(throwVector * force);

        float regreso = 5f;
        Invoke("Reinicio", regreso);
        
    }

    private void Reinicio()
    {
        transform.position = posicionInicial;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector3.zero;
    }
}