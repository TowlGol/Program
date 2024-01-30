using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;


[System.Serializable]
public class Atom
{
    [SerializeField]
    public int id;//原子编号
    [SerializeField]
    public string name;//原子名
    [SerializeField]
    public string parent;//氨基酸残基名
    [SerializeField]
    public int pid;//氨基酸编号
    [SerializeField]
    public Vector3 pos;//当前位置
    [SerializeField]
    public string element;//元素成分N/H/C

    public Atom(int id, string name, string parent, int pid, Vector3 pos, string element)
    {
        this.id = id;
        this.name = name;
        this.parent = parent;
        this.pid = pid;
        this.pos = pos;
        this.element = element;
    }
}

[System.Serializable]
public class Moment
{
    public List<Atom> model = new List<Atom>();
}

public class ParseTXT : MonoBehaviour
{
    [HideInInspector]
    public static List<Moment> atomAnimSquence = new List<Moment>();

    [HideInInspector]
    public static List<List<float>> amplitude = new List<List<float>>();

    [HideInInspector]
    public static List<float> min_amplitude = new List<float>();

    [HideInInspector]
    public static List<float> max_amplitude = new List<float>();

    [Tooltip("数据文本名")]
    public string txtName;


    [InspectorButton("清空解析数据")]
    public void ClearList()
    {
        if (atomAnimSquence.Count <= 0)
        {
            Debug.Log("Already Clear!");
            return;
        }

        atomAnimSquence.Clear();

        Debug.Log("Clear Successfully!");
    }


    [InspectorButton("解析文本数据")]
    public void ParseTxt()
    {
        if (atomAnimSquence.Count > 0)
        {
            Debug.Log("Already Parsed!");
            return;
        }

        string path = Path.Combine(Application.streamingAssetsPath, txtName + ".txt");

        string[] lines = null;
        if (File.Exists(path))
        {
            lines = File.ReadAllLines(path);
            SetSquence(lines);
            getAmplitude();
            Debug.Log("Parse Successfully!");
        }
        else
        {
            Debug.LogError("path error!");
        }

        

    }

    public void getAmplitude()
    {

        for(int i = 0; i < atomAnimSquence.Count; i++)
        {
            Moment pre, cur;

            pre = atomAnimSquence[i];
            cur = atomAnimSquence[i];
            if (i != 0)
                pre = atomAnimSquence[i - 1];
            

            


            float min = -1;
            float max = -1;
            List<float> temp = new List<float>();
            List<float> preTemp = new List<float>();
            if (i != 0)
                preTemp = amplitude[i - 1];
            
            for (int j = 0; j < cur.model.Count; j++)
            {
                if (i == 0)
                {
                    temp.Add(0);
                    min = max = 0;
                }
                else
                {
                    float dis = Vector3.Distance(cur.model[j].pos, pre.model[j].pos);
                    dis += preTemp[j];
                    temp.Add(dis);

                    if (min == -1 && max == -1)
                    {
                        min = max = dis;
                    }
                    else
                    {
                        if (dis < min)
                            min = dis;
                        if (dis > max)
                            max = dis;
                    }
                }
            }

            amplitude.Add(temp);
            min_amplitude.Add(min);
            max_amplitude.Add(max);

        }
    }


    public void SetSquence(string[] lines)
    {
        Moment moment = new Moment();
        //int n = 50000;
        foreach(string line in lines)
        {
            //Debug.Log(line.Length + " " + line);
            string[] item = new string[9];
            item[0] = line.Length >= 4 ? line.Substring(0, 4).Trim() : "";
            if (item[0] == "MODE")
            {
                moment = new Moment();
            }
            else if (item[0] == "ATOM")
            {
                item[1] = line.Substring(6, 5).Trim();
                item[2] = line.Substring(12, 4).Trim();
                item[3] = line.Substring(17, 3).Trim();
                item[4] = line.Substring(22, 4).Trim();

                item[5] = line.Substring(30, 8).Trim();
                item[6] = line.Substring(38, 8).Trim();
                item[7] = line.Substring(46, 8).Trim();

                item[8] = line.Substring(76, 1).Trim();

                int id = int.Parse(item[1]);
                string name = item[2];
                string parent = item[3];
                int pid = int.Parse(item[4]);
                float x, y, z;
                if (!float.TryParse(item[5], out x)) Debug.LogError(item[5] + " convert to float failed!");
                if (!float.TryParse(item[6], out y)) Debug.LogError(item[6] + " convert to float failed!");
                if (!float.TryParse(item[7], out z)) Debug.LogError(item[7] + " convert to float failed!");
                Vector3 pos = new Vector3(-x, y, z);
                string element = item[8];


                moment.model.Add(new Atom(id, name, parent, pid, pos, element));
            }
            else if (item[0] == "ENDM")
            {
                atomAnimSquence.Add(moment);
            }

            //if (n-- < 0)
            //    break;
        }
    }


}
