using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    RectTransform panel;
    Rect lastSafeArea;

    void Awake() { panel = GetComponent<RectTransform>(); ApplySafeArea(); }

    void Update()
    {
        if (Screen.safeArea != lastSafeArea) ApplySafeArea();
    }

    void ApplySafeArea()
    {
        Rect safe = Screen.safeArea;
        lastSafeArea = safe;

        Vector2 anchorMin = safe.position;
        Vector2 anchorMax = safe.position + safe.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;
    }
}
