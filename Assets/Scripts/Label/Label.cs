using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public Vector3 center;

    public Canvas canvas;

    public Text text;

    public GameObject target;

    public float distance;

    private void Awake()
    {
        this.target = GameObject.Find("target");
        //this.distance = 0.12f;
    }

    public void Init(Vector3 center)
    {
        this.center = center;
        

        GameObject canvasObj = new GameObject("canvas");
        canvas = canvasObj.AddComponent<Canvas>();
        canvasObj.AddComponent<CanvasScaler>().dynamicPixelsPerUnit = 10;
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;
        canvas.transform.position = center;
        canvasObj.transform.SetParent(transform);

        GameObject textObj = new GameObject("text");
        text = textObj.AddComponent<Text>();
        text.alignment = TextAnchor.MiddleCenter;
        text.text = transform.name;
        text.color = Color.red;
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textObj.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        textObj.transform.position = center;
        textObj.transform.SetParent(canvasObj.transform);
    }

    private void Update()
    {
        Vector3 dir = canvas.transform.position - Camera.main.transform.position ;
        canvas.transform.LookAt(canvas.transform.position + dir);

        if (target != null)
        {
            if (Vector3.Distance(canvas.transform.position, target.transform.position) < distance)
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }
}
