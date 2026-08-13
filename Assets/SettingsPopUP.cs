

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    [Header("Panel Pengaturan")]
    public GameObject settingPanel; // Panel pop-up pengaturan

    [Header("Audio")]
    public AudioClip bubbleClip; // Suara klik / bubble

    private bool isPanelActive = false;

    private void Start()
    {
        // Pastikan panel tertutup saat awal scene
        if (settingPanel != null)
            settingPanel.SetActive(false);
    }

    // 🔘 Dipanggil saat tombol setting diklik
    public void ToggleSettingPanel()
    {
        PlayBubbleSound();

        if (settingPanel == null)
        {
            Debug.LogWarning("Setting Panel belum dihubungkan di Inspector!");
            return;
        }

        isPanelActive = !isPanelActive;
        settingPanel.SetActive(isPanelActive);
    }

    // ❌ Dipanggil saat tombol "Close" (X) di dalam panel diklik
    public void CloseSettingPanel()
    {
        PlayBubbleSound();

        if (settingPanel == null)
        {
            Debug.LogWarning("Setting Panel belum dihubungkan di Inspector!");
            return;
        }

        isPanelActive = false;
        settingPanel.SetActive(false);
    }

    // 🔊 Fungsi untuk memainkan suara bubble
    private void PlayBubbleSound()
    {
        if (SFX.Instance != null && bubbleClip != null)
        {
            SFX.Instance.PlaySFX(bubbleClip);
        }
    }
}
