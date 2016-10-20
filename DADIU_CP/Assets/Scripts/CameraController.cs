using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;

    private Vector3 position;
    private Vector3 offset;

    private float rotationAngle;
    private float currentRotationAngle;

    private Quaternion currentRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(0, GameManager.instance.camY, GameManager.instance.camZ);
        GameManager.instance.active = true;
    }
    void LateUpdate()
    {
        if (GameManager.instance.active == true)
        {
            rotationAngle = player.transform.eulerAngles.y;

            currentRotationAngle = transform.eulerAngles.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, rotationAngle, Time.deltaTime * 3);

            currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = player.transform.position;
            transform.position -= currentRotation * Vector3.forward * 8;
            transform.position = new Vector3(transform.position.x, player.transform.position.y + GameManager.instance.camY, transform.position.z);
            transform.LookAt(player.transform);
        }
    }


    public void Cutscene(GameObject lookHere, Vector3 direction, float cutsceneDist, float cutsceneLength)
    {
        GameManager.instance.active = false;
        position = transform.position;
        transform.position = lookHere.transform.position + (direction * cutsceneDist) + new Vector3(0f, lookHere.transform.position.y * 3f, 0f);
        transform.LookAt(lookHere.transform);
        StartCoroutine(cutTimer(cutsceneLength));
    }

    IEnumerator cutTimer(float cutsceneLength)
    {
        yield return new WaitForSeconds(cutsceneLength);
        transform.position = position;
        transform.LookAt(player.transform.position);
        GameManager.instance.active = true;
    }
}