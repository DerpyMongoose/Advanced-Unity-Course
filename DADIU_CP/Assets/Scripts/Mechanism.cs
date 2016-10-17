using UnityEngine;
using System.Collections;

public class Mechanism : MonoBehaviour
{

    public enum doorPos
    {
        up,
        down,
        left,
        right,
    }
    public GameObject button;
    public GameObject door;
    public doorPos doorMovePos;
    public bool isReusable = false;
    public float lerpTimeToPosition;

    private bool doorHasLerped = false;
    private bool allowLerp = true;
    private bool isLerping = false;
    private bool hasCutscene = false;

    private float lerpTime;

    private Button button_;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 direction;

    public Color color;

    // Use this for initialization
    void Start()
    {
        switch (doorMovePos)
        {
            case doorPos.up:
            direction = Vector3.up;
            break;
            case doorPos.down:
            direction = Vector3.down;
            break;
            case doorPos.left:
            direction = Vector3.left;
            break;
            case doorPos.right:
            direction = Vector3.right;
            break;
            default:
            direction = Vector3.up;
            break;
        }

        if (button.GetComponent<ZoomScene>() != null)
        {
            hasCutscene = true;
        }

        button.GetComponent<Renderer>().material.color = color;
        door.GetComponent<Renderer>().material.color = color;
        button_ = button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(door.transform.position.x + "," + door.transform.position.y + "," + door.transform.position.z);
        if (button_.pushed == true)
        {
            if (allowLerp == true)
            {
                lerpTime = Time.time;

                startPos = door.transform.position;
                endPos = door.transform.position + direction*3;

                isLerping = true;
                allowLerp = false;
            }
            if (isLerping == true)
            {
                if (doorHasLerped == false)
                {
                    Lerp(endPos);
                }
                else Lerp(startPos);
            }
        }
    }

    void Lerp(Vector3 pos)
    {
        float timeSS = Time.time - lerpTime;
        float lerpPercentage = timeSS / lerpTimeToPosition;
        door.transform.position = Vector3.Lerp(door.transform.position, pos, lerpPercentage);

        if (lerpPercentage >= 1.0f)
        {
            Debug.Log("Done Lerping");
            isLerping = false;
            allowLerp = true;    
            if (doorHasLerped == true)
            {
                doorHasLerped = false;
            }
            else doorHasLerped = true;
            button_.pushed = false;
        }
        else isLerping = true;
    }
}
