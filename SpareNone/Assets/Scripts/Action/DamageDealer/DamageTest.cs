using Unity.VisualScripting;
using UnityEngine;
public class DamageTest : Action, IDamageDealer
{
    [SerializeField] int strength;
    [SerializeField] int damage;
    [SerializeField] Transform hitPoint;
    [SerializeField] LayerMask mask;

    
    public void InflictDamage(CreatureBehaviour Ennemy)
    {
        Debug.Log("hurting " + Ennemy.name);
        Ennemy.Hurt(damage);

    }

    public void Push(CreatureBehaviour Ennemy)
    {
        Ennemy.Push(strength, Vector3.Normalize(Ennemy.transform.position - transform.position));
    }

    protected override void PerformAction()
    {
        /*
        // we check fi there is a gameObject in front of us;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hitPoint.position, 0, mask);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<CreatureBehaviour>() != null)
        {
            InflictDamage(hit.collider.gameObject.GetComponent<CreatureBehaviour>());
        }
        Debug.Log(hit.collider);
        */
        float distance = Vector3.Distance(transform.position, hitPoint.position);
        
        Vector3 direction = new(hitPoint.position.x - transform.position.x, hitPoint.position.y - transform.position.y);
        
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distance, mask);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.GetComponent<CreatureBehaviour>() != null)
            {
                Debug.DrawLine(transform.position, hitPoint.position, Color.red, 1f);
                InflictDamage(hit.collider.GetComponent<CreatureBehaviour>());
                Push(hit.collider.GetComponent<CreatureBehaviour>());
            }
        }

    }
}