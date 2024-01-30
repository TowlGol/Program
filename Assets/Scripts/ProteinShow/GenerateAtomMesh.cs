using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateAtomMesh : MonoBehaviour
{
    [Tooltip("原子数量")]
    public int num;

    [Tooltip("原子半径")]
    public float radius;


    [HideInInspector]
    public GameObject[] atomObjs;


    public Slider slider;

    public Material material;

    //public GameObject target;

    //public int[] pokets;

    private void Awake()
    {
        atomObjs = new GameObject[num];
        if (slider != null)
            slider.onValueChanged.AddListener(OnValueChanged);
    }

    [InspectorButton("清空原子网格")]
    public void ClearAtoms()
    {
        if (atomObjs[0] == null)
        {
            Debug.Log("Already Clear!");
            return;
        }

        for(int i = 0; i < atomObjs.Length; i++)
        {
            DestroyImmediate(atomObjs[i]);
        }

        Debug.Log("Clear Successfully!");
    }

    [InspectorButton("生成原子网格")]
    public void GenerateAtoms()
    {
        if (ParseTXT.atomAnimSquence.Count <= 0)
        {
            Debug.LogError("no atomAnimSquence in ParseTXT!");
            return;
        }

        if (atomObjs[0] != null)
        {
            Debug.Log("Already Generate!");
            return;
        }

        

        List<Atom> atoms = ParseTXT.atomAnimSquence[0].model;

        GameObject parent = null;

        Vector3 center = Vector3.zero;
        for(int i = 0; i < atoms.Count; i++)
        {
            atomObjs[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            

            atomObjs[i].GetComponent<MeshRenderer>().material = new Material(material);
            atomObjs[i].transform.localScale = new Vector3(radius, radius, radius);
            AtomInstance atomInstance = atomObjs[i].AddComponent<AtomInstance>();
            atomInstance.Init(atoms[i].id, atoms[i].name, atoms[i].parent, atoms[i].pid, atoms[i].element);
            atomObjs[i].transform.localPosition = atoms[i].pos;

            

            string pname = atoms[i].parent + "_" + atoms[i].pid;
            if (parent == null || parent.name != pname)
            {
                if (parent != null)
                {
                    int n = parent.transform.childCount;
                    center /= n;

                    Label label = parent.AddComponent<Label>();
                    label.Init(center);

                    parent.transform.SetParent(transform);

                }

                parent = new GameObject(pname);
                center = Vector3.zero;
            }
            
            center += atoms[i].pos;           

            atomObjs[i].transform.SetParent(parent.transform);

            //atomObjs[i].SetActive(false);

            if (i == atoms.Count - 1)
            {
                int n = parent.transform.childCount;
                center /= n;

                Label label = parent.AddComponent<Label>();
                label.Init(center);

                parent.transform.SetParent(transform);
            }

            
        }

        Debug.Log("Generate Successfully!");

    }

    public void OnValueChanged(float value)
    {
        int index = (int)(value * (ParseTXT.atomAnimSquence.Count - 1));

        Moment moment = ParseTXT.atomAnimSquence[index];

        for (int i = 0; i < atomObjs.Length; i++)
        {
            atomObjs[i].transform.localPosition = moment.model[i].pos;

            float min = ParseTXT.min_amplitude[index];
            float max = ParseTXT.max_amplitude[index];
            float r = (ParseTXT.amplitude[index][i] - min) / (max - min);

            atomObjs[i].GetComponent<MeshRenderer>().material.color = new Color(r, 0, 0);
        }

    }



}
