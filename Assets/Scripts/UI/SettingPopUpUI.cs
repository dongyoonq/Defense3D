using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(() => { GameManager.Ui.ClosePopUpUI(); });
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.Ui.ShowPopUpUI<ConfigPopUpUI>("UI/ConfigPopUpUI"); });
        buttons["ExitButton"].onClick.AddListener(() => { GameManager.Ui.ShowPopUpUI<ExitPopUpUI>("UI/ExitPopUpUI"); });
    }
}