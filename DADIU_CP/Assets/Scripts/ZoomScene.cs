using UnityEngine;
using System.Collections;

public class ZoomScene : MonoBehaviour
{

    public GameObject target;

    private bool isActive;
    private GameObject cam;
    private CameraController cControl;

    // Use this for initialization
    void Start()
    {
        isActive = true;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cControl = cam.GetComponent<CameraController>();
        if(cControl = null)
        {
            cam.AddComponent<CameraController>();
        }
    }

    void Update()
    {
        if (GameManager.instance.isCutscene == true)
        {
            Debug.Log("isCutscene");
            cControl.Cutscene(target);
            GameManager.instance.isCutscene = false;
        }
    }

    void OnTriggerEnter()
    {
        if (isActive == true)
        {
            Debug.Log("Trigger");
            GameManager.instance.isCutscene = true;
            isActive = false;
        }
    }
}
