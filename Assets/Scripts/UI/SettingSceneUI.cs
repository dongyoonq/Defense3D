using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["InfoButton"].onClick.AddListener(() => { Debug.Log("InfoButton Click");  });
        buttons["SoundButton"].onClick.AddListener(() => { Debug.Log("SoundButton Click"); });
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.Ui.ShowPopUpUI<SettingPopUpUI>("UI/SettingPopUpUI"); });
    }
}
