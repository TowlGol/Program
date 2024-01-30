using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotate : MonoBehaviour
{
    Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = this.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles = rotate;
    }
}
