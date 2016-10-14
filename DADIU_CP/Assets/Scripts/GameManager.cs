using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool isCutscene = false;
    [Header("Camera Controls")]
    public float camX = 0;
    public float camY = 7.5f;
    public float camZ = -10f;
    public float cutsceneDistance = 3;
    public float cutsceneTime = 5;

    void Awake()
    {
        instance = this;
    }
}
