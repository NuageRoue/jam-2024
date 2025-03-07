using UnityEngine;

public class Stun : MonoBehaviour
{
    float timer;
    public bool Stunned
    {
        get; private set;
    }

    private void Start()
    {
        timer = 0;
        Stunned = false;
    }

    public void StunTimer(float time)
    {
        Stunned = true;
        timer += time;
        Debug.Log(name + ": stunned for " + timer);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Stunned = false;
        }
        Debug.Log(Stunned);
    }

}