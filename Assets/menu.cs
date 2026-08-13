
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [Header("Panel Menu")]
    public GameObject menupanel;
    public GameObject armenupanel;
    public GameObject tentangpanel;
    public GameObject keluarPopUpPanel;
    public GameObject unduhPopUpPanel;
    public GameObject settingpopupPanel;
    public GameObject arBiawanPopUpPanel;
    public GameObject arHaruanPopUpPanel;
    public GameObject arBetutuPopUpPanel;

    [Header("Tombol Menu")]
    public Button unduhButton;
    public Button keluarButton;
    public Button settingButton;
    public Button panduanButton;
    public Button arButton;
    public Button arBiawanButton;
    public Button arHaruanButton;
    public Button arBetutuButton;
    public Button tentangButton;
    public Button BackButtonAr;

    [Header("Audio Clips")]
    public AudioClip buttonClip;  // suara klik
    public AudioClip bubbleClip;  // suara bubble

    [Header("Link Unduh Marker")]
    public string url = "https://drive.google.com/drive/folders/1zzCkWBJB2ksEtYV2oyQtadUTzFWZ5Lxg?usp=drive_link";

    void Start()
    {
        // Atur semua panel ke kondisi awal
        menupanel.SetActive(true);
        armenupanel.SetActive(false);
        tentangpanel.SetActive(false);
        keluarPopUpPanel.SetActive(false);
        unduhPopUpPanel.SetActive(false);
        settingpopupPanel.SetActive(false);
        arBiawanPopUpPanel.SetActive(false);
        arHaruanPopUpPanel.SetActive(false);
        arBetutuPopUpPanel.SetActive(false);

        SetAllButtonsInteractable(true);

        // Cek jika pengguna terakhir membuka AR tertentu
        string lastAR = PlayerPrefs.GetString("LastAR");
        GameObject targetPanel = null;

        if (lastAR == "Detail Ar Biawan") targetPanel = arBiawanPopUpPanel;
        else if (lastAR == "Detail Ar Haruan") targetPanel = arHaruanPopUpPanel;
        else if (lastAR == "Detail Ar Betutu") targetPanel = arBetutuPopUpPanel;

        if (targetPanel != null)
        {
            menupanel.SetActive(false);
            armenupanel.SetActive(true);
            targetPanel.SetActive(true);
            PlayerPrefs.SetString("LastAR", ""); // reset
            SetAllButtonsInteractable(false);
        }

        // Tambahkan efek suara pada tombol
        AddButtonSoundEffects();
    }

    // ====== Tambahkan suara klik untuk semua tombol ======
    private void AddButtonSoundEffects()
    {
        if (keluarButton != null) keluarButton.onClick.AddListener(() => PlayBubbleSound());
        if (unduhButton != null) unduhButton.onClick.AddListener(() => PlayBubbleSound());
        if (settingButton != null) settingButton.onClick.AddListener(() => PlayBubbleSound());
        if (panduanButton != null) panduanButton.onClick.AddListener(() => PlayBubbleSound());
        if (arButton != null) arButton.onClick.AddListener(() => PlayBubbleSound());
        if (arBiawanButton != null) arBiawanButton.onClick.AddListener(() => PlayBubbleSound());
        if (arHaruanButton != null) arHaruanButton.onClick.AddListener(() => PlayBubbleSound());
        if (arBetutuButton != null) arBetutuButton.onClick.AddListener(() => PlayBubbleSound());
        if (tentangButton != null) tentangButton.onClick.AddListener(() => PlayBubbleSound());
    }

    // ====== Fungsi SFX ======
    public void PlayButtonSound()
    {
        if (SFX.Instance != null && buttonClip != null)
            SFX.Instance.PlaySFX(buttonClip);
    }

    public void PlayBubbleSound()
    {
        if (SFX.Instance != null && bubbleClip != null)
            SFX.Instance.PlaySFX(bubbleClip);
    }

    // ====== Navigasi Panel ======
    public void arButtonClik()
    {
        menupanel.SetActive(false);
        armenupanel.SetActive(true);
    }

    public void BackButtonArClick()
    {
        PlayBubbleSound();
        menupanel.SetActive(true);
        armenupanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    public void tentangButtonClick()
    {
        menupanel.SetActive(false);
        tentangpanel.SetActive(true);
    }

    public void BackButtonTentang()
    {
        PlayBubbleSound();
        menupanel.SetActive(true);
        tentangpanel.SetActive(false);
    }

    public void QuitButton()
    {
        PlayBubbleSound();
        Application.Quit();
        Debug.Log("Aplikasi ditutup.");
    }

    // ====== Popup Unduh ======
    public void ShowPopupUnduh()
    {
        unduhPopUpPanel.SetActive(true);
        SetAllButtonsInteractable(false);
    }

    public void ClosePopUpUnduh()
    {
        PlayBubbleSound();
        unduhPopUpPanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    public void UnduhMarker()
    {
        Application.OpenURL(url);
        ClosePopUpUnduh();
    }

    // ====== Popup Keluar ======
    public void ShowPopupKeluar()
    {
        PlayBubbleSound();
        keluarPopUpPanel.SetActive(true);
        SetAllButtonsInteractable(false);
    }

    public void ClosePopUpKeluar()
    {
        PlayBubbleSound();
        keluarPopUpPanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    // ====== Popup Setting ======
    public void ShowPopupSetting()
    {
        settingpopupPanel.SetActive(true);
        SetAllButtonsInteractable(false);
    }

    public void ClosePopupSetting()
    {
        PlayBubbleSound();
        settingpopupPanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    // ====== Popup AR ======
    public void arBiawanButtonClik()
    {
        arBiawanPopUpPanel.SetActive(true);
        SetAllButtonsInteractable(false);
    }

    public void ClosePopUpBiawan()
    {
        PlayBubbleSound();
        arBiawanPopUpPanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    public void arHaruanButtonClik()
    {
        arHaruanPopUpPanel.SetActive(true);
        SetAllButtonsInteractable(false);
    }

    public void ClosePopUpHaruan()
    {
        PlayBubbleSound();
        arHaruanPopUpPanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    public void arBetutuButtonClik()
    {
        arBetutuPopUpPanel.SetActive(true);
        SetAllButtonsInteractable(false);
    }

    public void ClosePopBetutu()
    {
        PlayBubbleSound();
        arBetutuPopUpPanel.SetActive(false);
        SetAllButtonsInteractable(true);
    }

    // ====== Helper ======
    private void SetAllButtonsInteractable(bool state)
    {
        if (unduhButton != null) unduhButton.interactable = state;
        if (keluarButton != null) keluarButton.interactable = state;
        if (settingButton != null) settingButton.interactable = state;
        if (panduanButton != null) panduanButton.interactable = state;
        if (arButton != null) arButton.interactable = state;
        if (arBiawanButton != null) arBiawanButton.interactable = state;
        if (arHaruanButton != null) arHaruanButton.interactable = state;
        if (arBetutuButton != null) arBetutuButton.interactable = state;
        if (tentangButton != null) tentangButton.interactable = state;
        if (BackButtonAr != null) BackButtonAr.interactable = state;
    }
}
