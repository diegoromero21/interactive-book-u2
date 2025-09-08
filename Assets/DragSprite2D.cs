using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragSprite2D : MonoBehaviour
{
    Camera cam;
    bool dragging;
    Vector3 offset;

    void Awake() { cam = Camera.main; }

    void OnMouseDown()
    {
        dragging = true;
        var p = cam.ScreenToWorldPoint(Input.mousePosition);
        p.z = transform.position.z;
        offset = transform.position - p;
    }

    void OnMouseUp() { dragging = false; }

    void Update()
    {
        if (!dragging) return;
        var p = cam.ScreenToWorldPoint(Input.mousePosition);
        p.z = transform.position.z;
        transform.position = p + offset;
    }
}
