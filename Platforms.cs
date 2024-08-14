using Oculus.Platform;
using Photon.Pun;
using System.Text;
using UnityEngine;

namespace BananaOS.Pages
{
    public class AirJump : WatchPage
    {
        //What will be shown on the main menu if DisplayOnMainMenu is set to true
        public override string Title => "AirJump";

        //Enabling will display your page on the main menu if you're nesting pages you should set this to false
        public override bool DisplayOnMainMenu => true;

        //This method will be ran after the watch is completely setup
        public override void OnPostModSetup()
        {
            //max selection index so the indicator stays on the screen
            selectionHandler.maxIndex = 5;
        }

        public bool Platforms { get; private set; }
        public static GameObject Platform1;
        public static bool Platform1Enable;
        public static GameObject Platform2;
        public static bool Platform2Enable;
        public static bool Platform1Disable;
        public static bool Platform2Disable;

        public void Update()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (!Platform1Enable)
                {
                    Platform1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Platform1.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position + new Vector3(0f, -0.045f, 0f);
                    Platform1Enable = true;
                    Platform1.transform.localScale = new Vector3(0.3f, 0.015f, 0.3f);
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
                    Platform2.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position + new Vector3(0f, -0.045f, 0f);
                    Platform2Enable = true;
                    Platform2.GetComponent<Renderer>().material = new Material(Shader.Find("Sprites/Default"));
                    Platform2.transform.localScale = new Vector3(0.3f, 0.015f, 0.3f);
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
        }

        //What you return is what is drawn to the watch screen the screen will be updated everytime you press a button
        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=red>==</color> DashMonke <color=red>==</color>");
            if (PhotonNetwork.InRoom && Moddedcheck.modcheck.IsModded())
            {
                if (Platforms)
                {
                    stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "On"));
                }
                else
                {
                    stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "Off"));
                }


            }
            else
            {
                stringBuilder.AppendLine("You aren't in a modded lobby");
            }
            return stringBuilder.ToString();
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
                    if (selectionHandler.currentIndex == 0)
                    {
                        if (!Platforms)
                        {
                            Platforms = true;
                        }
                        else
                        {
                            Platforms = false;
                        }
                    }
                    break;

                //It is recommended that you keep this unless you're nesting pages if so you should use the SwitchToPage method
                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}