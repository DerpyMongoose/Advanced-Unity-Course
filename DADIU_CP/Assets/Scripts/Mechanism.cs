using UnityEngine;
using System.Collections;

public class Mechanism : MonoBehaviour
{

    public GameObject button;
    public GameObject door;

    private Button button_;

    public Color color;

    // Use this for initialization
    void Start()
    {
        button.GetComponent<Renderer>().material.color = color;
        door.GetComponent<Renderer>().material.color = color;
        button_ = button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button_.pushed == true)
        {
            StartCoroutine("Animation");
        }
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(1);
        door.transform.position = Vector3.Lerp(door.transform.position, door.transform.position - new Vector3(0, 2, 0), Time.deltaTime);
    }
}
