using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    [SerializeField] GameObject cube, sphere, capsule, cilinder;
    bool inProgress;
    GameObject curObj;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            RaycastHit ray;
            if (curObj)
            {
                MovePrefab(touch);
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out ray) && ray.transform.tag == "Moveable")
            {
                if (!inProgress)
                {
                    StartCoroutine(Timer(ray));
                }   
            }
        }

        if (Input.touchCount <= 0 && curObj)
        {
            //Debug.Log("Empty");
            DropPrefab();
        }
    }

    IEnumerator Timer(RaycastHit ray)
    {
        inProgress = true;
        yield return new WaitForSeconds(1);
        inProgress = false;
        curObj = ray.transform.gameObject;
        curObj.GetComponent<Rigidbody>().useGravity = false;
        curObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    GameObject ReturnPrefab(int id)
    {
        switch (id)
        {
            case 0:
                return cube;
            case 1:
                return sphere;
            case 2:
                return capsule;
            case 3:
                return cilinder;
        }
        return null;
    }

    public bool CheckObj()
    {
        return curObj;
    }

    public void SpawnPrefab(int id)
    {
        GameObject temp = ReturnPrefab(id);
        touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        curObj = Instantiate(temp, ray.GetPoint(10), transform.rotation);
    }

    void MovePrefab(Touch t)
    {
        Ray ray = Camera.main.ScreenPointToRay(t.position);
        curObj.transform.position = Vector3.Lerp(curObj.transform.position, ray.GetPoint(10), 1f);
    }

    public void DropPrefab()
    {
        curObj.GetComponent<Rigidbody>().useGravity = true;
        curObj = null;
    }
}
