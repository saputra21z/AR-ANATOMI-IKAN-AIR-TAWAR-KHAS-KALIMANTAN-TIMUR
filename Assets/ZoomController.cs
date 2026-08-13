using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    [Header("Target Zoom")]
    public GameObject targetObject; // Objek 3D ikan

    [Header("Zoom Settings")]
    public float zoomSpeed = 0.1f;     // Kecepatan zoom
    public float smoothSpeed = 5f;     // Kecepatan interpolasi (halus)
    public float minScale = 0.5f;      // Skala minimum
    public float maxScale = 3f;        // Skala maksimum

    private Vector3 targetScale;       // Skala tujuan untuk efek halus

    void Start()
    {
        if (targetObject != null)
        {
            targetScale = targetObject.transform.localScale;
        }
    }

    void Update()
    {
        // Smooth zoom (lerp setiap frame)
        if (targetObject != null)
        {
            targetObject.transform.localScale = Vector3.Lerp(
                targetObject.transform.localScale,
                ClampScale(targetScale),
                Time.deltaTime * smoothSpeed
            );
        }
    }

    // Zoom In
    public void ZoomIn()
    {
        if (targetObject != null)
        {
            targetScale += Vector3.one * zoomSpeed;
            targetScale = ClampScale(targetScale);
        }
    }

    // Zoom Out
    public void ZoomOut()
    {
        if (targetObject != null)
        {
            targetScale -= Vector3.one * zoomSpeed;
            targetScale = ClampScale(targetScale);
        }
    }

    // Batasi ukuran min & max
    private Vector3 ClampScale(Vector3 scale)
    {
        float x = Mathf.Clamp(scale.x, minScale, maxScale);
        float y = Mathf.Clamp(scale.y, minScale, maxScale);
        float z = Mathf.Clamp(scale.z, minScale, maxScale);

        return new Vector3(x, y, z);
    }
}
