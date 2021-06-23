using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject HomeHolder;
    [SerializeField] private GameObject FloorsHolder;
    [SerializeField] private GameObject ModelsHolder;
    [SerializeField] private GameObject InfoHolder;

    public void ShowHolder(string holderName)
    {
        // HomeHolder.SetActive(false);
        ModelsHolder.SetActive(false);
        FloorsHolder.SetActive(false);
        InfoHolder.SetActive(false);
        
        if (holderName == "Home") HomeHolder.SetActive(true);
        if (holderName == "Floors") FloorsHolder.SetActive(true);
        if (holderName == "Models") ModelsHolder.SetActive(true);
        if (holderName == "Info") InfoHolder.SetActive(true);
    }
    public void Btn_ShowModels() { ShowHolder("Models"); }
    public void Btn_ShowHome() { ShowHolder("Home"); }
    public void Btn_ShowInfo() { ShowHolder("Info"); }
    public void Btn_SelectModel(GameObject prefab) { DataManager.Instance.model = prefab; }
    public void Btn_Screenshot()
    {
        int resWidth = Screen.width; ;
        int resHeight = Screen.height;

        //Take sceenshot
        try
        {
            DataManager.Instance.SetAllPlanesActive();

            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            DataManager.Instance.camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            DataManager.Instance.camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            DataManager.Instance.camera.targetTexture = null;
            byte[] mediaBytes = screenShot.EncodeToPNG();

            DataManager.Instance.SetAllPlanesActive();
            RenderTexture.active = null;
            Destroy(rt);

            NativeGallery.SaveImageToGallery(mediaBytes, "PHOTO", "DIE_SCUM.png");
            //Notificate
            var notification = new AndroidNotification();
            notification.Title = "Saved!";
            notification.Text = "Screenshot is saved to your device.";
            //notification.FireTime = System.DateTime.Now.AddMinutes(1);

            AndroidNotificationCenter.SendNotification(notification, "default");
            //GOTO forms
            Application.OpenURL("https://forms.gle/rRr2stFDDkTKQrXx6");
        }

        catch(System.Exception e) { DataManager.Instance.debug.text = e.Message; }
    }
}
