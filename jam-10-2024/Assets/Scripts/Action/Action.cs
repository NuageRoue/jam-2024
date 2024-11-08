using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{

    float cooldownDuration;

    float cooldownTimer;
    public void DoAction()
    {
        if (cooldownTimer <= 0)
        {
            Act();
            cooldownTimer = cooldownDuration;
        }
    }

    protected abstract void Act();


    protected void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
}
