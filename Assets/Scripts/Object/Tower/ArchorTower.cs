using UnityEngine;

public class ArchorTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/ArchorTowerData");
    }
}

