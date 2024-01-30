using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assmbly : MonoBehaviour {
    [SerializeField] private Transform Aim, PeiTi;
    public float radius;
    [SerializeField] private Transform parentGameObject;
    [SerializeField] private List<Transform> appearTranformList;
    [SerializeField] private List<Transform> disappearTranformList;

    private Vector3 distance;
    private Vector3 rotate;


    public bool isAssmbly;
    private bool assmblied;
    private void Awake() {
        rotate = transform.eulerAngles - parentGameObject.eulerAngles;
        distance = this.transform.position - PeiTi.position;
        assmblied = false;
        ControllAppearanceList(appearTranformList,false);
        ControllAppearanceList(disappearTranformList, true);
    }
    private void Update() {
        if (isAssmbly) {
            assmblyPeiTi();
        }
        else if(assmblied) {
            parentGameObject.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<ObjectManipulator>().enabled = true;
            assmblied = false;
            ControllAppearanceList(appearTranformList, false);
            ControllAppearanceList(disappearTranformList, true);
        }
    }
    private void assmblyPeiTi() {
        if (!assmblied && Vector3.Distance(Aim.position, PeiTi.position) < radius) {
            this.transform.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<ObjectManipulator>().enabled = false;
            PeiTi.position = Aim.position;
            PeiTi.eulerAngles = Aim.eulerAngles;
            //this.transform.position = distance + PeiTi.position;
            transform.localPosition = new Vector3(-12, 0.7225f, 12.1500f);
            this.transform.eulerAngles = rotate + transform.eulerAngles;
            parentGameObject.GetComponent<SphereCollider>().enabled = true;
            assmblied = true;

            
            ControllAppearanceList(disappearTranformList, false);
            ControllAppearanceList(appearTranformList, true);
        }
    }

    public void changeIsAssmbly() {
        isAssmbly = !isAssmbly;
    }
    private void ControllAppearanceList(List<Transform> transforms, bool active) {
        foreach (Transform transform in transforms) {
            if(transform != null)
            transform.gameObject.SetActive(active);
        }
    }
}
