using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] float maxDist, speed;
    Vector3 initPos;
    bool joyActive;
    RectTransform joy;
    // Start is called before the first frame update
    void Start()
    {
        joy = GetComponent<RectTransform>();
        initPos = joy.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (joyActive)
        {
            JoyStickMove();
        }
    }

    void JoyStickMove()
    {
        Touch touch = Input.GetTouch(0);
        //Ray ray = Camera.main.ScreenPointToRay(touch.position);
       // Debug.Log(touch.position);
        Vector2 pos = new Vector2(CheckBoundsX(touch.position.x), CheckBoundsY(touch.position.y));
        Debug.Log(pos);
        joy.localPosition += Vector3.Lerp(pos, joy.localPosition, speed) ;
    }

    float CheckBoundsX(float f)
    {
        if (f >= initPos.x + maxDist)
        {
            return initPos.x + maxDist;
        }
        else if(f <= initPos.x - maxDist)
        {
            return initPos.x - maxDist;
        }
        else
        {
            return f;
        }
    }

    float CheckBoundsY(float f)
    {
        if (f >= initPos.y + maxDist)
        {
            return initPos.y + maxDist;
        }
        else if (f <= initPos.y - maxDist)
        {
            return initPos.y - maxDist;
        }
        else
        {
            return f;
        }
    }

    public void TouchJoy()
    {
        joyActive = true;
    }

    public void ReleaseJoy()
    {
        joyActive = false;
        joy.localPosition += Vector3.Lerp(initPos, joy.localPosition, 1);
    }
}
