using UnityEngine;

public class MonsterTargetSystem : TargetSystem
{

    public override Vector3 TargetPos()
    {
        return target.position;
    }

    public void Update()
    {
        UpdateTarget();
    }

    public override void UpdateTarget()
    {
        target = GameObject.FindGameObjectWithTag("hero").transform;
    }

    
}