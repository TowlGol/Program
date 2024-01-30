using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class LockPosition : MonoBehaviour
{
    [SerializeField]private Transform imageTarget;
    [SerializeField]private Transform aimTransform;
    [SerializeField]private Transform baseTransfrom;
    [SerializeField] private Transform[] appearList;


    public void FixPosition() {
        imageTarget.GetComponent<ImageTargetBehaviour>().enabled = false;
        baseTransfrom.position = aimTransform.position;
        baseTransfrom.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        foreach(Transform transform in appearList) {
            transform.gameObject.SetActive(true);
        }
    }
}
