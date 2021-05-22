using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamControl : MonoBehaviour
{
    Vector3 initPos, initTouch;
    GameObject scrip;
    // Start is called before the first frame update
    void Start()
    {
        scrip = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.touchCount > 0 && !scrip.GetComponent<DragNDrop>().CheckObj())
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initPos = transform.position;
                    initTouch = touch.position/100;
                    break;

                case TouchPhase.Moved:
                    transform.position = Vector3.Lerp(transform.position, new Vector3(initPos.x - ((touch.position.x/100) -initTouch.x), initPos.y, initPos.z - ((touch.position.y/100) - initTouch.y)), 1);//Quaternion.Euler(initRot.x, initRot.y, initRot.z + touch.position.x);
                    break;

                case TouchPhase.Ended:
                    initPos = Vector3.zero;
                    break;
            }
        }
    }

    public void OnValueChanged(float zoom)
    {
        GetComponent<Camera>().fieldOfView = 40 + 30 * zoom;
    }
}
