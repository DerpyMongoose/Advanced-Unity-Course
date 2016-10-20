using UnityEngine;
using System.Collections;

public class ZoomScene : MonoBehaviour
{

    public enum direction
    {
        forwards, backwards, left, right
    }

    public float cutsceneTime = 5;
    public float cutsceneDistance = 3;
    public GameObject target;
    public direction direction_;

    private bool isCutscene = false;
    private Vector3 cutsceneDirection;
    private bool isActive;
    private GameObject cam;
    private CameraController cControl;

    // Use this for initialization
    void Start()
    {
        switch(direction_)
        {
            case direction.forwards:
            cutsceneDirection = Vector3.forward;
            break;
            case direction.backwards:
            cutsceneDirection = Vector3.back;
            break;
            case direction.left:
            cutsceneDirection = Vector3.left;
            break;
            case direction.right:
            cutsceneDirection = Vector3.right;
            break;
            default:
            cutsceneDirection = Vector3.forward;
            break;
        }

        isActive = true;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cControl = cam.GetComponent<CameraController>();
        if(cControl == null)
        {
            cam.AddComponent<CameraController>();
        }
    }

    void Update()
    {
        if (isCutscene == true)
        {
            cControl.Cutscene(target, cutsceneDirection, cutsceneDistance, cutsceneTime);
            isCutscene = false;
        }
    }

    void OnTriggerEnter()
    {
        if (isActive == true)
        {
            isCutscene = true;
            isActive = false;
        }
    }
}
