using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private EventSystem eventSystem;
    private Stack<PopUpUI> popUpUIStack;
    private Canvas popUpCanvas;
    private Canvas windowCanvas;
    private Canvas inGameCanvas;

    private void Awake()
    {
        popUpUIStack = new Stack<PopUpUI>();
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;

        windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        windowCanvas.gameObject.name = "WindowCanvas";
        windowCanvas.sortingOrder = 10;

        // gameScene.sortingOrder = 1;

        inGameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        inGameCanvas.gameObject.name = "InGameCanvas";
        inGameCanvas.sortingOrder = 0;
    }

    public T ShowPopUpUI<T>(T popUpUI) where T : PopUpUI
    {
        if (popUpUIStack.Count > 0)
        {
            PopUpUI prevUI = popUpUIStack.Peek();
            prevUI.gameObject.SetActive(false);
        }

        T ui = GameManager.Pool.GetUI(popUpUI);
        ui.transform.SetParent(popUpCanvas.transform, false);

        popUpUIStack.Push(ui);

        Time.timeScale = 0f;

        return ui;
    }

    public T ShowPopUpUI<T>(string path) where T : PopUpUI
    {
        Cursor.lockState = CursorLockMode.None;
        T ui = GameManager.Resource.Load<T>(path);
        ShowPopUpUI(ui);

        return ui;
    }

    public void ClosePopUpUI()
    {
        PopUpUI ui = popUpUIStack?.Pop();
        GameManager.Pool.Release(ui.gameObject);

        if (popUpUIStack.Count > 0)
        { 
            PopUpUI currUI = popUpUIStack.Peek();
            currUI.gameObject.SetActive(true);
        }
        else if (popUpUIStack.Count == 0)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public T ShowWindowUI<T>(T windowUI) where T : WindowUI
    {
        T ui = GameManager.Pool.GetUI(windowUI);
        ui.transform.SetParent(windowCanvas.transform, false);
        return ui;
    }
     
    public T ShowWindowUI<T>(string path) where T : WindowUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowWindowUI(ui);
    }

    public void CloseWindowUI<T>(T windowUI) where T : WindowUI
    {
        GameManager.Pool.ReleaseUI(windowUI.gameObject);
    }

    public void SelectWindowUI<T>(T windowUI) where T : WindowUI
    {
        windowUI.transform.SetAsLastSibling();
    }

    public T ShowInGameUI<T>(T inGameUI) where T : InGameUI
    {
        T ui = GameManager.Pool.GetUI(inGameUI);
        ui.transform.SetParent(inGameCanvas.transform, false);
        return ui;
    }

    public T ShowInGameUI<T>(string path) where T : InGameUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowInGameUI(ui);
    }

    public void CloseInGameUI<T>(T inGameUI) where T : InGameUI
    {
        GameManager.Pool.ReleaseUI(inGameUI.gameObject);
    }
}
