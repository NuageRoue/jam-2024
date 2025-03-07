using System;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(TargetSystem))]
[RequireComponent (typeof(Action))]
[RequireComponent (typeof(Stun))]
public class CreatureBehaviour : MonoBehaviour
{
    public Movement movement;
    TargetSystem targetSystem;
    Action action;
    Stun stun;

    public float weight;

    private void Start()
    {
        movement = GetComponent<Movement>();
        targetSystem = GetComponent<TargetSystem>();
        action = GetComponent<Action>();
        stun = GetComponent<Stun>();
    }
    private void Update()
    {
        if (!stun.Stunned)
        {
            // if we moved to the target :
            if (targetSystem.HasATarget() && movement.MoveTowards(targetSystem.TargetPos()))
            {
                if (action != null && action.Acts())
                    stun.StunTimer(action.recoveryTime);
            }
        }
    }
}
