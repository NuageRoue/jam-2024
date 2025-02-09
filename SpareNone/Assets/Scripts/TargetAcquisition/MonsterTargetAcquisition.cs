using UnityEngine;

public class MonsterTargetAcquisition : TargetAcquisition
{
    public override Vector3 GetTargetPos()
    {
        if (target != null)
            return target.position;
        return transform.position;
    }

    protected override bool GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("hero") != null)
        {
            target = GameObject.FindGameObjectWithTag("hero").transform;
            return true;
        }

        return false;
    }
}