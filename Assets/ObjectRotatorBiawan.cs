
using UnityEngine;
using Vuforia;

public class ObjectRotatorBiawan : MonoBehaviour
{
    [Header("Target dan Kecepatan")]
    public GameObject targetObject;
    public float rotationSpeed = 50f;
    public ObserverBehaviour marker; // Drag ImageTarget di sini

    private bool rotateRight;
    private bool rotateLeft;
    private bool rotateUp;
    private bool rotateDown;

    private bool markerTerdeteksi = false;

    void Start()
    {
        if (marker != null)
            marker.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Hanya anggap terdeteksi jika benar-benar TRACKED (kamera masih melihat marker)
        if (status.Status == Status.TRACKED)
        {
            markerTerdeteksi = true;
            Debug.Log("Marker Betutu TERDETEKSI");
        }
        else
        {
            markerTerdeteksi = false;
            StopAllRotation();
            Debug.Log("Marker Betutu HILANG");
        }
    }

    void Update()
    {
        if (targetObject == null || !markerTerdeteksi)
            return;

        // Rotasi kiri-kanan (sumbu Y)
        if (rotateRight)
            targetObject.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.Self);
        else if (rotateLeft)
            targetObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);

        // Rotasi atas-bawah (sumbu Z)
        if (rotateUp)
            targetObject.transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime, Space.Self);
        else if (rotateDown)
            targetObject.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }

    // Fungsi tombol UI
    public void RotateRight(bool state)
    {
        if (!markerTerdeteksi) return;
        rotateRight = state;
    }

    public void RotateLeft(bool state)
    {
        if (!markerTerdeteksi) return;
        rotateLeft = state;
    }

    public void RotateUp(bool state)
    {
        if (!markerTerdeteksi) return;
        rotateUp = state;
    }

    public void RotateDown(bool state)
    {
        if (!markerTerdeteksi) return;
        rotateDown = state;
    }

    private void StopAllRotation()
    {
        rotateRight = rotateLeft = rotateUp = rotateDown = false;
    }

    void OnDisable()
    {
        StopAllRotation();
    }

    void OnDestroy()
    {
        if (marker != null)
            marker.OnTargetStatusChanged -= OnTargetStatusChanged;
    }
}

