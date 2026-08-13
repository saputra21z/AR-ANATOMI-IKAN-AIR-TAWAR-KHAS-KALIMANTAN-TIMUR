
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe_control : MonoBehaviour
{
    public GameObject scrollbar;
    public AudioClip buttonSFX;   // Sound efek tombol
    public GameObject nextButton; // Tombol Next
    public GameObject prevButton; // Tombol Prev

    float scroll_pos = 0;
    float[] pos;
    int posisi = 0;

    void Start()
    {
        if (scrollbar != null)
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        UpdateButtonVisibility();
    }

    public void next()
    {
        if (posisi < pos.Length - 1)
        {
            posisi += 1;
            scroll_pos = pos[posisi];
            PlayClickSFX();
            UpdateButtonVisibility();
        }
    }

    public void prev()
    {
        if (posisi > 0)
        {
            posisi -= 1;
            scroll_pos = pos[posisi];
            PlayClickSFX();
            UpdateButtonVisibility();
        }
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(
                        scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f
                    );
                    posisi = i;
                }
            }
        }

        UpdateButtonVisibility();
    }

    private void PlayClickSFX()
    {
        if (SFX.Instance != null && buttonSFX != null)
        {
            SFX.Instance.PlaySFX(buttonSFX);
        }
        else
        {
            Debug.LogWarning("⚠️ SFX Manager atau Button SFX belum di-assign!");
        }
    }

    private void UpdateButtonVisibility()
    {
        // Pastikan pos sudah dibuat sebelum dicek
        if (pos == null || pos.Length == 0)
            return;

        if (nextButton != null)
            nextButton.SetActive(posisi < pos.Length - 1);

        if (prevButton != null)
            prevButton.SetActive(posisi > 0);
    }

}