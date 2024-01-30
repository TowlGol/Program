using Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Vuforia;

#region 脚本用途
/// <summary>
/// SyncOffLineRequest
/// @ 创建人：刘亚鹏
/// @ 创建时间：2022/6/14 8:42:15
/// @ 作用:
///     固定模型
///     
///     
///     
/// </summary>
#endregion
public class PositionLocate: MonoBehaviour
{

    public void ReSetPositon()
    {
        GameObject.Find("ImageTarget").transform.position = GameObject.Find("SceneRoot").transform.position;
        GameObject.Find("ImageTarget").transform.localEulerAngles = GameObject.Find("SceneRoot").transform.localEulerAngles;
        GameObject.Find("ImageTarget").transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        GameObject.Find("SceneRoot").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("ImageTarget").GetComponent<ImageTargetBehaviour>().enabled = true;
        //Debug.Log("ResetPosition");

    }
    public void SetPosition()
    {
        GameObject.Find("SceneRoot").transform.position = GameObject.Find("ImageTarget").transform.position;
        GameObject.Find("SceneRoot").transform.localEulerAngles = GameObject.Find("ImageTarget").transform.localEulerAngles ;
        GameObject.Find("SceneRoot").transform.localScale = Vector3.one;
        GameObject.Find("ImageTarget").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("ImageTarget").GetComponent<ImageTargetBehaviour>().enabled = false;
        //Debug.Log("SetPosition");
    }
}
