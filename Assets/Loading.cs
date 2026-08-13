using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image loadingBar;   // Drag & Drop Image Loading Bar dari Inspector
    [SerializeField] private float nilaiSekarang;
    [SerializeField] private float nilaiKecepatan;
    [SerializeField] private string namaScene;   // Nama Scene tujuan

    void Update()
    {
        if (nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Debug.Log((int)nilaiSekarang);

            if (loadingBar != null)
                loadingBar.fillAmount = nilaiSekarang / 100f;
        }
        else
        {
            SceneManager.LoadScene("Main Menu"); // Load scene tujuan
        }
    }
}


