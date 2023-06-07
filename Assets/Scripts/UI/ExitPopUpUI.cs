using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["YesButton"].onClick.AddListener(() => { ExitGame(); });
        buttons["NoButton"].onClick.AddListener(() => { GameManager.Ui.ClosePopUpUI(); });

    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
