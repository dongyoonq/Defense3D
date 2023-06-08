using UnityEngine;

public class CanonTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
    }
}

