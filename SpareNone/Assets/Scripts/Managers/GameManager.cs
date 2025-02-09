using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    // controller to get the inputs;

    bool spawnMode = false;
    float mana;

    float duration;

    private void Start()
    {
        duration = 0;
        spawnMode = false;
    }
}