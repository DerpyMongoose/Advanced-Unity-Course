using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private bool active;
    private GameObject player;
    private Vector3 position;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(GameManager.instance.camX, GameManager.instance.camY, GameManager.instance.camZ);
        transform.parent = player.transform;
    }

    public void Update()
    {
        if (active == true)
        {
            transform.LookAt(player.transform.position);
        }
    }

    public void Cutscene(GameObject lookHere, Vector3 direction, float cutsceneDist, float cutsceneLength)
    {
        active = false;
        position = transform.position;
        transform.parent = null;
        transform.position = lookHere.transform.position + (direction * cutsceneDist) + new Vector3(0f, lookHere.transform.position.y * 3f, 0f);
        transform.LookAt(lookHere.transform);
        StartCoroutine(cutTimer(cutsceneLength));
    }

    IEnumerator cutTimer(float cutsceneLength)
    {
        yield return new WaitForSeconds(cutsceneLength);
        transform.position = position;
        transform.parent = player.transform;
        active = true;
    }
}