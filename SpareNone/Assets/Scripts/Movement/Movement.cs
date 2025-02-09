using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool orient;
    public bool MoveTowards(Vector3 target, float distance)
    {
        Vector3 normalizedDirection = Vector3.Normalize(target - transform.position);

        if (orient)
        {
            OrientTowards(normalizedDirection);
        }
        if (Vector3.Distance(target, transform.position + speed * Time.deltaTime * normalizedDirection) - distance < 
            Vector3.Distance(target, transform.position) - distance
            && Vector3.Distance(target, transform.position + speed * Time.deltaTime * normalizedDirection) > distance)
        {
            transform.position += normalizedDirection * speed * Time.deltaTime;
            return false;
        }
        return true;
    }

    void OrientTowards(Vector3 direction) 
    {
        if (direction.x < 0)
        {
            transform.localScale = new(transform.localScale.x,
                                       - Mathf.Abs(transform.localScale.y),
                                       transform.localScale.z);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new(transform.localScale.x,
                                       Mathf.Abs(transform.localScale.y),
                                       transform.localScale.z);
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}