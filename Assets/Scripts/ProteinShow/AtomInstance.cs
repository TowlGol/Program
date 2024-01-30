using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomInstance : MonoBehaviour
{
    [SerializeField]
    int id;//ԭ�ӱ��
    [SerializeField]
    string name;//ԭ����
    [SerializeField]
    string parent;//������л���
    [SerializeField]
    int pid;//��������
    [SerializeField]
    string element;//Ԫ�سɷ�N/H/C


    public void Init(int id, string name, string parent, int pid, string element)
    {
        this.id = id;
        this.name = name;
        this.parent = parent;
        this.pid = pid;
        this.element = element;
    }
}
