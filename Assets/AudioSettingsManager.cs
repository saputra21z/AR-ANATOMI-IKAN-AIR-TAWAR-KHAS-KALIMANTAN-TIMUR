using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    [Header("Tombol UI Musik")]
    public Image musicOnImage;
    public Image musicOffImage;

    [Header("Tombol UI SFX")]
    public Image sfxOnImage;
    public Image sfxOffImage;

    [Header("Suara Klik Tombol")]
    public AudioClip buttonClickSFX;

    private void Start()
    {
        // 🔁 Sinkronisasi awal UI dengan status audio
        SyncMusicUI();
        SyncSFXUI();
    }

    // ========== SWITCH MUSIK ==========
    public void ToggleMusic()
    {
        PlayClickSFX(); // 🔊 mainkan suara klik dulu

        bool isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        isMuted = !isMuted; // ubah statusnya

        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        if (BGM.Instance != null)
            BGM.Instance.SetMute(isMuted);

        SyncMusicUI();
    }

    private void SyncMusicUI()
    {
        bool isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;

        if (musicOnImage != null && musicOffImage != null)
        {
            musicOnImage.gameObject.SetActive(!isMuted);
            musicOffImage.gameObject.SetActive(isMuted);
        }

        if (BGM.Instance != null)
            BGM.Instance.SetMute(isMuted);
    }

    // ========== SWITCH SFX ==========
    public void ToggleSFX()
    {
        PlayClickSFX(); // 🔊 mainkan suara klik juga di sini

        bool isMuted = PlayerPrefs.GetInt("SFXMuted", 0) == 1;
        isMuted = !isMuted;

        PlayerPrefs.SetInt("SFXMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        if (SFX.Instance != null)
            SFX.Instance.SetMute(isMuted);

        SyncSFXUI();
    }

    private void SyncSFXUI()
    {
        bool isMuted = PlayerPrefs.GetInt("SFXMuted", 0) == 1;

        if (sfxOnImage != null && sfxOffImage != null)
        {
            sfxOnImage.gameObject.SetActive(!isMuted);
            sfxOffImage.gameObject.SetActive(isMuted);
        }

        if (SFX.Instance != null)
            SFX.Instance.SetMute(isMuted);
    }

    // 🔊 Fungsi untuk memainkan suara klik tombol
    private void PlayClickSFX()
    {
        if (SFX.Instance != null && buttonClickSFX != null && !SFX.Instance.IsMuted())
        {
            SFX.Instance.PlaySFX(buttonClickSFX);
        }
    }
}

