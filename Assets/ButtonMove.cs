using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMove : MonoBehaviour
{
    [SerializeField] float speed;
    bool movingV, movingH;
    Vector3 directionH, directionV;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movingH || movingV)
        {
            transform.Translate((directionH + directionV) * speed * Time.deltaTime);
        }
    }

    public void DirectionalMoveH(int i)
    {
        movingH = true;
        directionH = new Vector3(i, 0, 0);
    }

    public void DirectionalMoveV(int i)
    {
        movingV = true;
        directionV = new Vector3(0, 0, i);
    }

    /*void DirectionCheck(string d)
    {
        if (d == "Down")
        {
            direction = new Vector3(0, 0, -1);
        }
        else if (d == "Up")
        {
            direction = new Vector3(0, 0, 1);
        }
        if (d == "Left")
        {
            direction = new Vector3(-1, 0, 0);
        }
        if (d == "Right")
        {
            direction = new Vector3(1, 0, 0);
        }
    }

    public void ActivateMove(string s)
    {
        DirectionCheck(s);
        isMoving = true;
    }*/

    public void DeactivateMove()
    {
        directionV = Vector3.zero;
        movingV = false;
    }

    public void DeactivateMoveH()
    {
        movingH = false;
        directionH = Vector3.zero;
    }
}
