using UnityEngine;

public class BuildInUI : InGameUI
{
    private TowerPlace towerPlace;
    public TowerPlace TowerPlace { get { return towerPlace; } set { towerPlace = value; } }

    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => { base.CloseUI(); });
        buttons["ArchorButton"].onClick.AddListener(() => { BuilderTower("Data/ArchorTowerData"); });
        buttons["CanonButton"].onClick.AddListener(() => { BuilderTower("Data/CanonTowerData"); });
    }

    private void BuilderTower(string resourcePath)
    {
        TowerData towerData = GameManager.Resource.Load<TowerData>(resourcePath);

        if (towerData == null)
            Debug.Log("타워 데이터 블러오기 실패");
        else
            towerPlace.BuildTower(towerData);

        base.CloseUI();
    }
}