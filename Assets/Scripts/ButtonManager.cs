using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject FloorsHolder;
    [SerializeField] private GameObject ModelsHolder;
    [SerializeField] private GameObject HomeHolder;

    private void ShowHolder(string holderName)
    {
        ModelsHolder.SetActive(false);
        FloorsHolder.SetActive(false);
        HomeHolder.SetActive(false);
        if (holderName == "ModelsHolder") ModelsHolder.SetActive(true);
        if (holderName == "FloorsHolder") FloorsHolder.SetActive(true);
        if (holderName == "HomeHolder") HomeHolder.SetActive(true);
    }
    public void Btn_ShowModels() { ShowHolder("ModelsHolder"); }
    public void Btn_HideModels() { ShowHolder("HomeHolder"); }
    public void Btn_SelectModel(GameObject prefab) { DataManager.Instance.model = prefab; }
    public void Btn_Screenshot()
    {
        int resWidth = 480;
        int resHeight = 800;

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
