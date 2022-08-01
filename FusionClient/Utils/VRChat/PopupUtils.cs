﻿using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace FusionClient.Utils.VRChat
{
    public static class PopupUtils
    {
        public static void HideCurrentPopUp()
        {
            VRCUiManager.prop_VRCUiManager_0.HideScreen("POPUP");
        }

        public static void InformationAlert(string Message, float DurationTime = 5)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_Single_0("Fusion Client", Message, DurationTime);
        }

        public static void Alert(string Message, string ButtonText, Action Action, Action<VRCUiPopup> OnPopupShown = null)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0("Fusion Client", Message, ButtonText, Action, OnPopupShown);
        }

        public static void AlertV2(string Message, string LeftButtonTXT, Action LeftButtonAction, string RightButtonTXT, Action RightButtonAction, Il2CppSystem.Action<VRCUiPopup> OnPopupShown = null)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_0("Fusion Client", Message, LeftButtonTXT, LeftButtonAction, RightButtonTXT, RightButtonAction, OnPopupShown);
        }

        public static void AlertV2(string Message, string ButtonText, Action onSuccess, Il2CppSystem.Action<VRCUiPopup> OnPopupShown = null)
        {
            AlertV2(Message, ButtonText, new Action(() =>
            {
                onSuccess.Invoke();
                HideCurrentPopUp();
            }), "Cancel", delegate { HideCurrentPopUp(); }, OnPopupShown);
        }

        public static void AskConfirmOpenURL(string url, string location)
        {
            //APIStuff.GetQuickMenuInstance().Method_Public_Virtual_Final_New_Void_String_3(url);
            AlertV2($"You are about to be redirected to [{location}], are you sure you want to continue?", "Open URL", delegate { Process.Start(url); }, "Return", HideCurrentPopUp);
        }

        public static void InputPopup(string AcceptButtonTXT, string DefaultInputBoxTXT, Action<string> AcceptButtonAction, Action CancelButtonAction = null)
        {
            PopupCall(AcceptButtonTXT, DefaultInputBoxTXT, false, AcceptButtonAction, CancelButtonAction);
        }

        public static void NumericPopup(string AcceptButtonTXT, string DefaultInputBoxTXT, Action<string> AcceptButtonAction, Action CancelButtonAction = null)
        {
            PopupCall(AcceptButtonTXT, DefaultInputBoxTXT, true, AcceptButtonAction, CancelButtonAction);
        }

        private static void PopupCall(string confirm, string placeholder, bool IsNumpad, Action<string> OnAccept, Action OnCancel = null)
        {
            VRCUiPopupManager
                .prop_VRCUiPopupManager_0
                .Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(
                    "Fusion Client",
                    "",
                    InputField.InputType.Standard,
                    IsNumpad,
                    confirm,
                    UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>(new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((a, _, _) =>
                    {
                        OnAccept?.Invoke(a);
                    })),
                    UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(OnCancel),
                    placeholder);
        }
    }
}