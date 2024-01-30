using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public GameObject roader;
    private bool fixFlag = false;
    private bool hideFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixScenePosition()
    {
        GetComponent<BoxCollider>().enabled = fixFlag;
        fixFlag = !fixFlag;
    }

    public void HideRoader()
    {
        roader.SetActive(hideFlag);
        hideFlag = !hideFlag;
    }

}
