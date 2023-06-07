using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private EventSystem eventSystem;
    private Stack<PopUpUI> popUpUIStack;
    private Canvas popUpCanvas;

    private void Awake()
    {
        popUpUIStack = new Stack<PopUpUI>();
        eventSystem = GameManager.Resouce.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resouce.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;
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
        T ui = GameManager.Resouce.Load<T>(path);
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
}
