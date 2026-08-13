using UnityEngine;
using UnityEngine.UI;

public class PopupDetailArManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject popupPanel;   // Drag "Informasi PoP Up Panel" ke sini
    public Button closeButton;      // Drag "Close Button" ke sini

    void Start()
    {
        // Tampilkan pop up saat program dijalankan
        if (popupPanel != null)
            popupPanel.SetActive(true);

        // Pastikan tombol close bekerja
        if (closeButton != null)
            closeButton.onClick.AddListener(TutupPopup);
    }

    public void TutupPopup()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}
