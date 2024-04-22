using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IdleState : State
{
    float randomTime;
    float timer;
    public void OnEnter(Enemy enemy)
    {
        enemy.Stop();
        timer = 0;
        randomTime = Random.Range(2f,5f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            enemy.ChangeState(new PatrolState());
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }

}
