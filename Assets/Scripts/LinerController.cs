using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinerController : MonoBehaviour {
    [SerializeField] private Transform circlePeiTi;
    [SerializeField] private Transform surfacePeiTi;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform distanceLabelTransform;
    [SerializeField] private Assmbly assmbly;
    [SerializeField] private Transform PRO_2Transform;
    [SerializeField] private Transform SER_3Transform;

    private Vector3 PRO_2;
    private Vector3 SER_3;
    private float aDistance;
    private float uDistance;

    private void Start() {
        PRO_2 = new Vector3(119.698f, 139.647f, 81.162f);
        SER_3 = new Vector3(117.6545f, 142.591f, 82.116f);
        aDistance = Vector3.Distance(SER_3, PRO_2);
        uDistance = Vector3.Distance(PRO_2Transform.position, SER_3Transform.position);
    }
    private void Update() {
        float distance = Vector3.Distance(circlePeiTi.position, surfacePeiTi.position);
        if (distance > assmbly.radius) {
            lineRenderer.gameObject.SetActive(true);
            distanceLabelTransform.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, circlePeiTi.position);
            lineRenderer.SetPosition(1, surfacePeiTi.position);
            distanceLabelTransform.position = (circlePeiTi.position + surfacePeiTi.position) / 2 +new Vector3(0,0.03f,0);
            distanceLabelTransform.GetComponent<Text>().text = (distance * (aDistance / uDistance)).ToString() + "Å";
            //Debug.Log(circlePeiTi.position + " " + surfacePeiTi.position);
        }
        else {
            lineRenderer.gameObject.SetActive(false);
            distanceLabelTransform.gameObject.SetActive(false);
        }
    }
}
