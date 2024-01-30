using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

#region 项目概述
/// <summary>
/// CommenClass
/// @ 创建人：刘亚鹏
/// @ 创建时间：2022/10/14 15:49:15
/// @ 作用:
///     
///     
///     
///     
/// </summary>
#endregion
namespace Assets.Scripts.CommonClass
{
    public class CommonClass : MonoBehaviour
    {
        public static CommonClass Instance;
        public CommonClass()
        {
            Instance = this;
        }
        public Material OnSelectMaterial;
        public List<GameObject> objList;
        public List<Material> objMaterialList;
        public bool onSelected;
        public string lastCategoryName;

        public Material[] materials;
        public GameObject barchartPrefab;

    }
}
