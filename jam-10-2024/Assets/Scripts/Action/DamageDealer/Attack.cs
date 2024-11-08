using System.Collections;
using UnityEngine;

public class Attack : Action, IDamageDealer
{
    [SerializeField] int damage;
    [SerializeField] Transform hitPoint;
    LayerMask hitLayerMask;
    protected override void Act()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hitPoint.position, hitLayerMask);
        
        if (hit)
        {
            DamageTo(hit.transform.gameObject.GetComponent<Life>());
        }
            

    }


    public void DamageTo(Life life)
    {
        throw new System.NotImplementedException();
    }
}
