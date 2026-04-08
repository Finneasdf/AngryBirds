using UnityEngine;

public class Pajarito : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private bool estoyArrastrando = false;
    private Vector3 offset;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detectar click con Raycast 2D
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            Debug.Log("Click en: " + mousePos + " | Hit: " + hit.collider);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                estoyArrastrando = true;
                rb.gravityScale = 0;
                rb.linearVelocity = Vector2.zero;
                offset = transform.position - (Vector3)mousePos;
                Debug.Log("Pajaro clickeado!");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            estoyArrastrando = false;
            rb.gravityScale = 1;
        }

        if (estoyArrastrando)
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (Vector3)mousePos + offset;
        }
    }
}