using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Target))]
[RequireComponent(typeof(Action))]
public class Behaviour : MonoBehaviour
{
    [SerializeField] protected float sigma;
    [SerializeField] protected bool isStatic;
    protected Target target;
    protected Movement movement;
    protected Action action;
    public bool canAttainFlying;

    public bool isFlying;


    private void Start()
    {
        target = GetComponent<Target>();
        movement = GetComponent<Movement>();
        action = GetComponent<Action>();
    }

    private void Update()
    {
        if (!isStatic && target.GetDistanceToTarget() > sigma)
        {
            movement.MoveTowards(target.GetNormalizedDirection());
        }
        else if (!isStatic)
        {
            action.Act();
        }
    }
}