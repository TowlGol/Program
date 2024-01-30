using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CollisionPrefab;
    public int CollisionFlag = 0;
    private GameObject go = null;
    private int DisplayFlag = 0;

    private void Update()
    {
        if (CollisionFlag == 1)
        {
            if (go == null)
            {
                go = GameObject.Instantiate(CollisionPrefab);
                go.transform.parent = this.transform.parent.transform;
            }
            go.transform.localPosition = this.transform.localPosition;
            go.transform.eulerAngles = this.transform.eulerAngles;
            go.transform.localScale = this.transform.localScale + new Vector3(0.001f, 0.001f, 0.001f);
            go.SetActive(true);
            if (DisplayFlag++ == 60)
                CollisionFlag = 0;
        }
        else
        {
            DisplayFlag = 0;
            CollisionFlag = 0;
            try
            {
                go.transform.localScale = new Vector3(0, 0, 0);
            }
            catch
            {

            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (go == null)
        {
            go = GameObject.Instantiate(CollisionPrefab);
            go.transform.parent = this.transform.parent.transform;
        }
        go.transform.localScale = this.transform.localScale + new Vector3(0.001f, 0.001f, 0.001f);
        go.transform.localPosition = this.transform.localPosition;
        go.SetActive(true);
        CollisionFlag = 1;

    }
    private void OnCollisionExit(Collision collision)
    {
        CollisionFlag = 0;
        go.transform.localScale = new Vector3(0, 0, 0);
    }
}
