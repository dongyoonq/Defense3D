using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArchorTower : Tower
{
    [SerializeField] Transform archor;
    [SerializeField] Transform arrowPoint;

    [SerializeField] int attackDamage;
    [SerializeField] float attackDelay;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
        StartCoroutine(LookRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemies.Count > 0)
            {
                if (enemies[0].IsValid())
                    Attack(enemies[0]);
                yield return new WaitForSeconds(attackDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            if (enemies.Count > 0)
            {
                if (enemies[0].IsValid())
                {
                    Vector3 dir = (enemies[0].transform.position - transform.position).normalized;
                    archor.transform.rotation = Quaternion.Lerp(archor.transform.rotation, Quaternion.LookRotation(dir), 0.1f);
                }
            }

            yield return null;
        }
    }

    public void Attack(Enemy enemy)
    {
        Arrow arrow = GameManager.Resource.Instantiate<Arrow>("Prefab/Arrow", arrowPoint.position, Quaternion.LookRotation(enemy.transform.position), true);
        arrow.SetTarget(enemy);
        arrow.SetDamage(attackDamage);
    }
}