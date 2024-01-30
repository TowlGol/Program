using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomInstance : MonoBehaviour
{
    [SerializeField]
    int id;//原子编号
    [SerializeField]
    string name;//原子名
    [SerializeField]
    string parent;//氨基酸残基名
    [SerializeField]
    int pid;//氨基酸编号
    [SerializeField]
    string element;//元素成分N/H/C


    public void Init(int id, string name, string parent, int pid, string element)
    {
        this.id = id;
        this.name = name;
        this.parent = parent;
        this.pid = pid;
        this.element = element;
    }
}
