using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailArInternalBetutu : MonoBehaviour
{
    [SerializeField] private GameObject popupPanel; // drag Informasi Ar Pop Up Panel ke Inspector

    void Start()
    {
        // otomatis muncul ketika program dijalankan
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }
    }

    // Fungsi untuk menutup popup
    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    // Fungsi untuk membuka popup kembali
    public void OpenPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }
    }
}
