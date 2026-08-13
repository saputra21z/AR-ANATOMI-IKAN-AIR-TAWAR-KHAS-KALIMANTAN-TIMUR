//using UnityEngine;
//using Vuforia;

//[System.Serializable]
//public class ObjekData
//{
//    public string markerName;              // Nama marker di database (contoh: "betutu02")
//    public GameObject objek3D;             // Objek 3D yang akan muncul
//    public ObserverBehaviour markerObject; // Drag ImageTarget dari scene ke sini
//}

//public class Objek3DManager : MonoBehaviour
//{
//    public ObjekData[] semuaObjek;
//    public GameObject trackingUI;  // ⬅️ Drag GameObject "Tracking Objek 3D" ke sini di Inspector

//    private GameObject currentObjek;

//    void Start()
//    {
//        // Pastikan tracking UI aktif di awal
//        if (trackingUI != null)
//            trackingUI.SetActive(true);

//        foreach (var data in semuaObjek)
//        {
//            if (data.markerObject != null)
//            {
//                // Sembunyikan semua objek 3D di awal
//                SembunyikanObjek(data);

//                var observer = data.markerObject;
//                observer.OnTargetStatusChanged += (behaviour, status) =>
//                {
//                    // Jika marker dilacak (TRACKED / EXTENDED_TRACKED)
//                    if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
//                    {
//                        // Tampilkan objek 3D
//                        SembunyikanSemuaObjek();
//                        TampilkanObjek(data);

//                        // Sembunyikan frame tracking
//                        if (trackingUI != null)
//                            trackingUI.SetActive(false);
//                    }
//                    else
//                    {
//                        // Marker hilang → sembunyikan objek 3D
//                        SembunyikanObjek(data);

//                        // Tampilkan kembali frame tracking
//                        if (trackingUI != null)
//                            trackingUI.SetActive(true);
//                    }
//                };
//            }
//        }
//    }

//    void TampilkanObjek(ObjekData data)
//    {
//        if (data.objek3D != null)
//        {
//            data.objek3D.SetActive(true);
//            currentObjek = data.objek3D;
//        }
//    }

//    void SembunyikanObjek(ObjekData data)
//    {
//        if (data.objek3D != null)
//            data.objek3D.SetActive(false);
//    }

//    void SembunyikanSemuaObjek()
//    {
//        foreach (var d in semuaObjek)
//        {
//            if (d.objek3D != null)
//                d.objek3D.SetActive(false);
//        }
//    }
//}


using UnityEngine;
using Vuforia;

[System.Serializable]
public class ObjekData
{
    public string markerName;              // Nama marker di database (contoh: "betutu02")
    public GameObject objek3D;             // Objek 3D yang akan muncul
    public ObserverBehaviour markerObject; // Drag ImageTarget dari scene ke sini
}

public class Objek3DManager : MonoBehaviour
{
    public ObjekData[] semuaObjek;

    private GameObject currentObjek;

    void Start()
    {
        foreach (var data in semuaObjek)
        {
            if (data.markerObject != null)
            {
                // Sembunyikan semua objek 3D di awal
                SembunyikanObjek(data);

                var observer = data.markerObject;
                observer.OnTargetStatusChanged += (behaviour, status) =>
                {
                    // Jika marker dilacak (TRACKED / EXTENDED_TRACKED)
                    if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
                    {
                        // Tampilkan objek 3D
                        SembunyikanSemuaObjek();
                        TampilkanObjek(data);
                    }
                    else
                    {
                        // Marker hilang → sembunyikan objek 3D
                        SembunyikanObjek(data);
                    }
                };
            }
        }
    }

    void TampilkanObjek(ObjekData data)
    {
        if (data.objek3D != null)
        {
            data.objek3D.SetActive(true);
            currentObjek = data.objek3D;
        }
    }

    void SembunyikanObjek(ObjekData data)
    {
        if (data.objek3D != null)
            data.objek3D.SetActive(false);
    }

    void SembunyikanSemuaObjek()
    {
        foreach (var d in semuaObjek)
        {
            if (d.objek3D != null)
                d.objek3D.SetActive(false);
        }
    }
}
