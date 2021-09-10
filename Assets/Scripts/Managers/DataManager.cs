using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;

public class DataManager : MonoBehaviour
{
    /* Instance */
    private static DataManager instance;
    public static DataManager Instance {get {if (instance == null) instance = FindObjectOfType<DataManager>(); return instance;}}
    

    /* Public variables */
    public Camera camera;
    public GameObject model;
    
    // /* plane visibility */
    // public GameObject arSession;
    // private bool m_PlaneVisible = false;
    // public void SetAllPlanesActive() 
    // {
    //     m_PlaneVisible = !m_PlaneVisible;
    // }
    // void Update() 
    // {
    //     foreach (var plane in arSession.GetComponent<ARPlaneManager>().trackables) {
    //         plane.gameObject.SetActive(m_PlaneVisible);
    //     }
    // }

    void Start() 
    {
        /* Setup */
        AndroidNotificationChannel NotificationChannel = new AndroidNotificationChannel() {
            Id = "default",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(NotificationChannel);
    }

    public void MakeScreenshot()
    {
        try
        {

            /* Variables declare */
            // SetAllPlanesActive();
            int resWidth = Screen.width;
            int resHeight = Screen.height;
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = rt;

            /* Take data from camera */
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            camera.targetTexture = null;
            byte[] mediaBytes = screenShot.EncodeToPNG();

            /* Variables cleanse */
            // SetAllPlanesActive();
            RenderTexture.active = null;
            Destroy(rt);

            /* Save and notificate */
            NativeGallery.SaveImageToGallery(mediaBytes, "PHOTO", "DIE_SCUM.png");
            var notification = new AndroidNotification();
            notification.Title = "Saved!";
            notification.Text = "Screenshot is saved to your device.";
            //notification.FireTime = System.DateTime.Now.AddMinutes(1);
            AndroidNotificationCenter.SendNotification(notification, "default");
            

            Application.OpenURL("https://forms.gle/rRr2stFDDkTKQrXx6");
        }
        catch { }
    }

}