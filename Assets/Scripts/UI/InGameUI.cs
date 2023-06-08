using UnityEngine;

public class InGameUI : BaseUI
{
    private Transform followTarget;
    public Vector2 followOffset;

    private void LateUpdate()
    {
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    public void SetTarget(Transform target)
    {
        this.followTarget = target;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    public void SetOffset(Vector2 offset)
    {
        followOffset = offset;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    public override void CloseUI()
    {
        GameManager.Ui.CloseInGameUI(this);
    }
}