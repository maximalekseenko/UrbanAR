using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance { get { if (instance == null) instance = FindObjectOfType<DataManager>(); return instance; } }


    public Text debug;
    public Camera camera;
    public GameObject model;


    public GameObject arSession;
    private bool m_PlaneVisible = false;
    public void SetAllPlanesActive()
    {
        m_PlaneVisible = !m_PlaneVisible;
    }


    void Start()
    {
        AndroidNotificationChannel NotificationChannel = new AndroidNotificationChannel()
        {
            Id = "default",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(NotificationChannel);
    }
    void Update()
    {
        foreach (var plane in arSession.GetComponent<ARPlaneManager>().trackables)
        {
            plane.gameObject.SetActive(m_PlaneVisible);
        }
    }
}