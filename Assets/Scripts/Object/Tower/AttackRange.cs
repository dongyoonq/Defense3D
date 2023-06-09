using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public LayerMask enemyMask;

    public UnityEvent<Enemy> OnInRangeEnemy;
    public UnityEvent<Enemy> OnOutRangeEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            OnInRangeEnemy?.Invoke(enemy);
            enemy.OnDied.AddListener(() => { OnOutRangeEnemy?.Invoke(enemy); });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            OnOutRangeEnemy?.Invoke(enemy);
        }
    }
}