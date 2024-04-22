using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float hp;

    private string curentAnimName;


    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        hp = 100;
    }

    public virtual void OnDesparm()
    {

    }

    protected virtual void OnDeath()
    {
        ChangeAnim("Died");

        Invoke(nameof(OnDesparm), 2f);
    }

    protected void ChangeAnim(string animName)
    {
        if (curentAnimName != animName)
        {
            animator.ResetTrigger(animName);

            curentAnimName = animName;

            animator.SetTrigger(curentAnimName);
        }
    }

    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;

            if (IsDead)
            {
                OnDeath();
            }
        }
    }
}
