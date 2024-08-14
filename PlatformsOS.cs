using Photon.Pun;
using Photon.Realtime;
using System.Text;
using UnityEngine;
using Utilla;

namespace BananaOS.Pages
{
    public class PlatformsPage : WatchPage
    {
        //What will be shown on the main menu if DisplayOnMainMenu is set to true
        public override string Title => "Platforms";

        //Enabling will display your page on the main menu if you're nesting pages you should set this to false
        public override bool DisplayOnMainMenu => true;

        //This method will be ran after the watch is completely setup
        public override void OnPostModSetup()
        {
            //max selection index so the indicator stays on the screen
            selectionHandler.maxIndex = 3;
        }

        public static GameObject Platform1;
        public static bool Platform1Enable;
        public static GameObject Platform2;
        public static bool Platform2Enable;
        public static bool Platform1Disable;
        public static bool Platform2Disable;
        public static GameObject Platform3;
        public static bool Platform3Enable;
        public static GameObject Platform4;
        public static bool Platform4Enable;
        public static bool Platform3Disable;
        public static bool Platform4Disable;
        public static GameObject Platform5;
        public static bool Platform5Enable;
        public static GameObject Platform6;
        public static bool Platform6Enable;
        public static bool Platform5Disable;
        public static bool Platform6Disable;
        public bool Platforms { get; private set; }
        public bool Platforms1 { get; private set; }
        public bool Platforms2 { get; private set; }

        //What you return is what is drawn to the watch screen the screen will be updated everytime you press a button
        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=green>==</color> <color=red> Platforms 0.0.2 </color> <color=green>==</color>");
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "Enable Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(1, "Disable Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(2, "Enable Plank Plats"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(3, "Disable Plank Plats"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(4, ""));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(5, "By FireGiraffe"));
            return stringBuilder.ToString();
        }

        public void Update()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED_"))
            {
                if (Platforms == true)
                {
                    if (ControllerInputPoller.instance.rightGrab)
                    {
                        if (!Platform1Enable)
                        {
                            Platform1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform1.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position + new Vector3(0f, -0.02f, 0f);
                            Platform1.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation * Quaternion.Euler(0f, 0f, -90f);
                            Platform1Enable = true;
                            Platform1.transform.localScale = new Vector3(0.28f, 0.015f, 0.38f);
                            Platform1.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                        }
                    }
                    else
                    {
                        if (Platform1Enable)
                        {
                            UnityEngine.Object.Destroy(Platform1);
                            Platform1Enable = false;
                            return;
                        }
                    }
                    if (ControllerInputPoller.instance.leftGrab)
                    {
                        if (!Platform2Enable)
                        {
                            Platform2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform2.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position + new Vector3(0f, -0.02f, 0f);
                            Platform2.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation * Quaternion.Euler(0f, 0f, -90f);
                            Platform2Enable = true;
                            Platform2.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                            Platform2.transform.localScale = new Vector3(0.28f, 0.015f, 0.38f);
                        }
                    }
                    else
                    {
                        if (Platform2Enable)
                        {
                            UnityEngine.Object.Destroy(Platform2);
                            Platform2Enable = false;
                            return;
                        }
                    }
                    if (PhotonNetwork.InRoom && !Moddedcheck.modcheck.IsModded())
                    {
                        UnityEngine.Object.Destroy(Platform1);
                        Platform1Enable = false;
                        Platform1Disable = true;
                        UnityEngine.Object.Destroy(Platform2);
                        Platform2Enable = false;
                        Platform2Disable = true;
                        return;
                    }
                }
                if (Platforms1 == true)
                {
                    if (ControllerInputPoller.instance.rightGrab)
                    {
                        if (!Platform3Enable)
                        {
                            Platform3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform3.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position + new Vector3(0f, -0.02f, 0f);
                            Platform3.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation * Quaternion.Euler(0f, 0f, -90f);
                            Platform3Enable = true;
                            Platform3.transform.localScale = new Vector3(0.28f, 0.015f, 0.53f);
                            Platform3.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                        }
                    }
                    else
                    {
                        if (Platform3Enable)
                        {
                            UnityEngine.Object.Destroy(Platform3);
                            Platform3Enable = false;
                            return;
                        }
                    }
                    if (ControllerInputPoller.instance.leftGrab)
                    {
                        if (!Platform4Enable)
                        {
                            Platform4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform4.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position + new Vector3(0f, -0.02f, 0f);
                            Platform4.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation * Quaternion.Euler(0f, 0f, -90f);
                            Platform4Enable = true;
                            Platform4.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                            Platform4.transform.localScale = new Vector3(0.28f, 0.015f, 0.53f);
                        }
                    }
                    else
                    {
                        if (Platform4Enable)
                        {
                            UnityEngine.Object.Destroy(Platform4);
                            Platform4Enable = false;
                            return;
                        }
                    }
                    if (PhotonNetwork.InRoom && !Moddedcheck.modcheck.IsModded())
                    {
                        UnityEngine.Object.Destroy(Platform3);
                        Platform3Enable = false;
                        Platform3Disable = true;
                        UnityEngine.Object.Destroy(Platform4);
                        Platform4Enable = false;
                        Platform4Disable = true;
                        return;
                    }
                }
            } 
        }

        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Enter:
                    if (PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED_"))
                    {
                        if (selectionHandler.currentIndex == 0)
                        {
                            Platforms = true;
                        }
                        if (selectionHandler.currentIndex == 1)
                        {
                            Platforms = false;
                        }
                        if (selectionHandler.currentIndex == 2)
                        {
                            Platforms1 = true;
                        }
                        if (selectionHandler.currentIndex == 3)
                        {
                            Platforms1 = false;
                        }
                    }
                    return;


                //It is recommended that you keep this unless you're nesting pages if so you should use the SwitchToPage method
                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}
