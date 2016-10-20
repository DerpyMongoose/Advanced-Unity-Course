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
        forward,
        backward,
    }
    public GameObject button;
    public GameObject door;
    public doorPos doorMovePos;
    public bool isReusable = false;
    public Color colorInactive;
    public Color colorActive;
    public float distance;

    private bool setColor = true;
    private bool doorHasLerped = false;
    private bool allowLerp = true;
    private bool isLerping = false;

    private Button button_;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 direction;



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
            case doorPos.forward:
                direction = Vector3.forward;
                break;
            case doorPos.backward:
                direction = Vector3.back;
                break;
            default:
                direction = Vector3.up;
                break;
        }

        button.GetComponent<Renderer>().material.color = colorInactive;
        door.GetComponent<Renderer>().material.color = colorInactive;

        startPos = door.transform.position;
        endPos = door.transform.position + direction * distance;

        button_ = button.GetComponent<Button>();
    }

    void Update()
    {
        if (button_.pushed == false && setColor == true && isReusable == true)
        {
            button.GetComponent<Renderer>().material.color = colorInactive;
            setColor = false;
        }
        if (button_.pushed == true)
        {
            if (allowLerp == true)
            {
                button.GetComponent<Renderer>().material.color = colorActive;
                isLerping = true;
                allowLerp = false;
            }
            if (isLerping == true)
            {
                if (doorHasLerped == false)
                {
                    Lerp(endPos);
                }
                else if (doorHasLerped == true && isReusable == true)
                {
                    Lerp(startPos);
                }
            }
        }
    }

    void Lerp(Vector3 pos)
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, pos, Time.deltaTime);

        if (door.transform.position == pos)
        {
            isLerping = false;
            allowLerp = true;
            if (doorHasLerped == true)
            {
                doorHasLerped = false;
            }
            else doorHasLerped = true;
            button_.pushed = false;
            setColor = true;
        }
        else isLerping = true;
    }
}
