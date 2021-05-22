using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touche : MonoBehaviour
{
    [SerializeField] GameObject go;
    Vector3 initRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            go.transform.position = Vector2.Lerp(ray.GetPoint(10), go.transform.position, 0.5f);
        }
    }

    void Rotation()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initRot = transform.rotation.eulerAngles;
                    break;

                case TouchPhase.Moved:
                    transform.rotation = Quaternion.Euler(initRot.x, initRot.y, initRot.z + touch.position.x);
                    break;

                case TouchPhase.Ended:
                    initRot = Vector3.zero;
                    break;
            }
        }
    }
}
