using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.UI.Image;

public class Attack : Action, IDamageDealer
{
    [SerializeField] int damage;
    [SerializeField] Transform hitPoint;
    [SerializeField] LayerMask hitLayerMask;
    Target target;

    private void Start()
    {
        target = GetComponent<Target>();
    }
    float distance
    {
        get { return Vector3.Distance(transform.position, hitPoint.position); }
    }
    Vector3 direction
    {
        get { return new (hitPoint.position.x - transform.position.x, hitPoint.position.y - transform.position.y);}
    }
    protected override void Act()
    {
        Debug.Log("Attacking 1");
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distance, hitLayerMask);

        foreach (RaycastHit2D hit in hits)
        {       
            if (hit.collider != null)
            {
                Debug.DrawLine(transform.position, hitPoint.position, Color.red, 1f) ;
                Debug.Log(hit.collider.name);
                DamageTo(hit.transform.gameObject.GetComponent<Life>());
            }
        }
    }


    public void DamageTo(Life life)
    {
        if (life.InflictDamage(damage))
            target.SetTarget(null);
    }
}
