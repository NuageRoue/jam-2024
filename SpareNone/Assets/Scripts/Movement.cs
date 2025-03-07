using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;


public class Movement : MonoBehaviour
{

    [SerializeField] float radius;
    [SerializeField] float speed;
    [SerializeField] bool orient;

    [SerializeField] float knockbackDuration = .2f;
    float knockbackTimer;
    Vector3 knockback;
    public bool MoveTowards(Vector3 posToGo)
    {
        

        Vector3 normalizedDirection = Vector3.Normalize(posToGo - transform.position);
        if (!CantGoCloser(posToGo, normalizedDirection))
        {
            OrientTowards(normalizedDirection);
            transform.position += speed * Time.deltaTime * normalizedDirection;
        }
        return CantGoCloser(posToGo, normalizedDirection) && knockbackTimer <= 0;
    }

    private bool CantGoCloser(Vector3 posToGo, Vector3 normalizedDirection)
    {
        return (knockbackTimer > 0) || (Vector3.Distance(posToGo, transform.position) <= radius) || (Vector3.Distance(posToGo, transform.position) <= Vector3.Distance(posToGo,transform.position + speed * Time.deltaTime * normalizedDirection));
    }

    private void OrientTowards(Vector3 normalizedDirection)
    {
        if (orient)
        {
            float angle = Mathf.Atan2(Mathf.Sign(normalizedDirection.x) * normalizedDirection.y, Mathf.Abs(normalizedDirection.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (normalizedDirection.x < 0)
            transform.localScale = new(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (normalizedDirection.x > 0)
            transform.localScale = new(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {
        if (knockbackTimer > 0)
        {
            transform.position += knockback * Time.deltaTime;
            knockbackTimer -= Time.deltaTime;
        }
        else
        {
            knockbackTimer = 0;
        }
    }

    public void Impulse(Vector3 _knockback)
    {
        if (knockbackTimer > 0)
            return;
        knockbackTimer = knockbackDuration;
        knockback = _knockback;
    }


}