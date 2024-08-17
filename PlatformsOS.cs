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
            selectionHandler.maxIndex = 7;
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
        public static GameObject StickPlat;
        public static GameObject StickPlat1;
        public static GameObject Platform7;
        public static bool Platform7Enable;
        public static GameObject Platform8;
        public static bool Platform8Enable;
        public static bool Platform7Disable;
        public static bool Platform8Disable;
        public static bool StickyPlatEnable;
        public static bool StickyPlatDisable;
        public static bool StickyPlatEnable1;
        public static bool StickyPlatDisable1;
        public static GameObject Platform9;
        public static bool Platform9Enable;
        public static GameObject Platform10;
        public static bool Platform10Enable;
        public static bool Platform9Disable;
        public static bool Platform10Disable;
        private static float transitionDuration = 3f;
        private static float elapsedTime = 0f;

        public bool Platforms { get; private set; }
        public bool Platforms1 { get; private set; }
        public bool Platforms2 { get; private set; }
        public bool Platforms3 { get; private set; }
        public bool Platforms4 { get; private set; }

        public bool Platforms5 { get; private set; }

        //What you return is what is drawn to the watch screen the screen will be updated everytime you press a button
        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=green>==</color><color=red> Platforms V0.3.0 </color><color=green>==</color>");
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "Enable Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(1, "Disable Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(2, "Enable Plank Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(3, "Disable Plank Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(4, "Enable No-Rotate Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(5, "Disable No-Rotate Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(6, "Enable RGB Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(7, "Disable RGB Platforms"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(11, "<color=yellow>Made by FireGiraffe</color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(12, "<color=yellow>Help from Striker</color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(13, "<color=yellow>Ideas from BoominLOL</color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(14, "<color=yellow>Tested By window</color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(15, "<color=yellow>Tested By Dragon8</color>"));
            return stringBuilder.ToString();
        }

        // if u looked at the open source hi :3

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
                            Platform1.GetComponent<Renderer>().material.color = Color.black;
                            Platform1Enable = true;
                            Platform1.transform.localScale = new Vector3(0.28f, 0.015f, 0.38f);
                            Platform1.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform1.GetComponent<Renderer>().material.color = Color.black;
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
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
                            Platform2.GetComponent<Renderer>().material.color = Color.black;
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform2.GetComponent<Renderer>().material.color = Color.black;
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
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
                            Platform3.GetComponent<Renderer>().material.color = Color.black;
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform3.GetComponent<Renderer>().material.color = Color.black;
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
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
                        if (elapsedTime < transitionDuration)
                        {
                            Platform4.GetComponent<Renderer>().material.color = Color.black;
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
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
                if (Platforms2 == true)
                {
                    if (ControllerInputPoller.instance.rightGrab)
                    {
                        if (!Platform5Enable)
                        {
                            Platform5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform5.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position + new Vector3(0f, -0.02f, 0f);
                            Platform5.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation * Quaternion.Euler(0f, 0f, -90f);
                            Platform5Enable = true;
                            Platform5.transform.localScale = new Vector3(0.28f, 0.015f, 0.38f);
                            Platform5.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                            Platform5.GetComponent<Renderer>().material.color = Color.HSVToRGB((Time.time * 0.5f) % 1f, 1f, 1f);
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform5.GetComponent<Renderer>().material.color = Color.HSVToRGB((Time.time * 0.5f) % 1f, 1f, 1f);
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
                        }
                    }
                    else
                    {
                        if (Platform5Enable)
                        {
                            UnityEngine.Object.Destroy(Platform5);
                            Platform5Enable = false;
                            return;
                        }
                    }
                    if (ControllerInputPoller.instance.leftGrab)
                    {
                        if (!Platform6Enable)
                        {
                            Platform6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform6.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position + new Vector3(0f, -0.02f, 0f);
                            Platform6.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation * Quaternion.Euler(0f, 0f, -90f);
                            Platform6Enable = true;
                            Platform6.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                            Platform6.transform.localScale = new Vector3(0.28f, 0.015f, 0.38f);
                            Platform6.GetComponent<Renderer>().material.color = Color.HSVToRGB((Time.time * 0.5f) % 1f, 1f, 1f);
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform6.GetComponent<Renderer>().material.color = Color.HSVToRGB((Time.time * 0.5f) % 1f, 1f, 1f);
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
                        }
                    }
                    else
                    {
                        if (Platform6Enable)
                        {
                            UnityEngine.Object.Destroy(Platform6);
                            Platform6Enable = false;
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
                if (Platforms3 == true)
                {
                    if (ControllerInputPoller.instance.rightGrab)
                    {
                        if (!Platform7Enable)
                        {
                            Platform7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform7.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position + new Vector3(0f, -0.062f, 0f);
                            Platform7Enable = true;
                            Platform7.transform.localScale = new Vector3(0.35f, 0.02f, 0.35f);
                            Platform7.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                            Platform7.GetComponent<Renderer>().material.color = Color.black;
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform7.GetComponent<Renderer>().material.color = Color.black;
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
                        }
                    }
                    else
                    {
                        if (Platform7Enable)
                        {
                            UnityEngine.Object.Destroy(Platform7);
                            Platform7Enable = false;
                            return;
                        }
                    }
                    if (ControllerInputPoller.instance.leftGrab)
                    {
                        if (!Platform8Enable)
                        {
                            Platform8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Platform8.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position + new Vector3(0f, -0.062f, 0f);
                            Platform8Enable = true;
                            Platform8.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                            Platform8.transform.localScale = new Vector3(0.38f, 0.02f, 0.38f);
                            Platform8.GetComponent<Renderer>().material.color = Color.black;
                        }
                        if (elapsedTime < transitionDuration)
                        {
                            Platform8.GetComponent<Renderer>().material.color = Color.black;
                            elapsedTime += Time.deltaTime;
                            if (elapsedTime >= transitionDuration)
                            {
                                elapsedTime = 0f;
                            }
                        }
                    }
                    else
                    {
                        if (Platform8Enable)
                        {
                            UnityEngine.Object.Destroy(Platform8);
                            Platform8Enable = false;
                            return;
                        }
                    }
                    if (PhotonNetwork.InRoom && !Moddedcheck.modcheck.IsModded())
                    {
                        UnityEngine.Object.Destroy(Platform7);
                        Platform7Enable = false;
                        Platform7Disable = true;
                        UnityEngine.Object.Destroy(Platform8);
                        Platform8Enable = false;
                        Platform8Disable = true;
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
                        if (selectionHandler.currentIndex == 4)
                        {
                            Platforms3 = true;
                        }
                        if (selectionHandler.currentIndex == 5)
                        {
                            Platforms3 = false;
                        }
                        if (selectionHandler.currentIndex == 6)
                        {
                            Platforms2 = true;
                        }
                        if (selectionHandler.currentIndex == 7)
                        {
                            Platforms2 = false;
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
