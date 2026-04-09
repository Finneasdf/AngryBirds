using UnityEngine;


public class Pajarito : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        
        Vector3 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        dragPosition.z = transform.position.z;
        transform.position = dragPosition;
    }
}