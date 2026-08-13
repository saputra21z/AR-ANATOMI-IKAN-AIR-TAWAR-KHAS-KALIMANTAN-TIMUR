using UnityEngine;
using Vuforia;

public class AutoShowOnTrack : MonoBehaviour
{
    [Header("Objek yang akan aktif ketika marker terdeteksi")]
    public GameObject objek3D;

    [Header("UI Buttons yang ikut tampil")]
    public GameObject uiButtons;

    private DefaultObserverEventHandler eventHandler;

    void Start()
    {
        // Ambil komponen DefaultObserverEventHandler dari ImageTarget
        eventHandler = GetComponent<DefaultObserverEventHandler>();

        if (eventHandler == null)
        {
            Debug.LogError("❌ DefaultObserverEventHandler tidak ditemukan di " + gameObject.name);
            return;
        }

        // Pastikan objek tidak tampil di awal (bisa diubah sesuai kebutuhan)
        if (objek3D != null) objek3D.SetActive(false);
        if (uiButtons != null) uiButtons.SetActive(false);

        // Tambahkan event listener otomatis
        eventHandler.OnTargetFound.AddListener(OnTargetFound);
        eventHandler.OnTargetLost.AddListener(OnTargetLost);
    }

    private void OnTargetFound()
    {
        Debug.Log("✅ Marker ditemukan!");
        if (objek3D != null) objek3D.SetActive(true);
        if (uiButtons != null) uiButtons.SetActive(true);
    }

    private void OnTargetLost()
    {
        Debug.Log("⚠️ Marker hilang!");
        if (objek3D != null) objek3D.SetActive(false);
        if (uiButtons != null) uiButtons.SetActive(false);
    }
}
