using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoor : MonoBehaviour
{
    [SerializeField] float OpenRepeatTime;
    [SerializeField] float CloseRepeatTime;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(DoorCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoorCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(OpenRepeatTime);
            animator.SetBool("Open", true);
            yield return new WaitForSeconds(CloseRepeatTime);
            animator.SetBool("Open", false);
        }
    }
}
