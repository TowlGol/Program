using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectContent
{
    public List<GameObject> meshRenderers;
}
namespace XCMG.VR.UI
{
    public class CrossProductAssemblyController : MonoBehaviour
    {

        public List<ObjectContent> selectedObjects;
        public List<Material> materials;
        public MeshRenderer testMeshRenderer;
        public int selectedNum = 0;

        public void ChangeSelectedObjects(int objectIndex)
        {
            objectIndex--;
            if(objectIndex<0 || objectIndex >= selectedObjects.Count)
            {
                Debug.LogError("index out of the range of selectedObjects!");
                return;
            }
            selectedNum = objectIndex;
            Debug.LogWarning("Change Select Object To Index: " + (objectIndex+1));
        }

        public void ChangeAllMaterial(int materialIndex)
        {
            
            Debug.LogWarning("ChangeAllMateria materialIndex: " + materialIndex+ " selectedNum : " + selectedNum);
            materialIndex--;
            if (materialIndex < 0 || materialIndex >= materials.Count)
            {
                Debug.LogError("index out of the range of materials!");
                return;
            }
            // change alpha of material

            int cnt = 0;
            // change mr self and its child material

            foreach (GameObject mr in selectedObjects[selectedNum].meshRenderers)
            {    
                foreach(MeshRenderer mr2 in mr.GetComponentsInChildren<MeshRenderer>())
                {
                    Debug.LogWarning("change child renderer" + mr.name + " index : " + cnt++);
                    mr2.material = materials[materialIndex];
                }
                if(mr.GetComponent<MeshRenderer>() != null)
                    mr.GetComponent<MeshRenderer>().material = materials[materialIndex];
            }
        }
        public void ChangeMaterialAccurate(int materialIndex)
        {
            materialIndex--;
            if (materialIndex < 0 || materialIndex >= materials.Count)
            {
                Debug.LogError("index out of the range of materials!");
                return;
            }
            foreach (GameObject mr in selectedObjects[selectedNum].meshRenderers)
            {
                if (mr.GetComponent<MeshRenderer>())
                    mr.GetComponent<MeshRenderer>().material = materials[materialIndex];
            }
        }
        public void ChangeColor()
        {
            return;
        }
        // unused
        public void ChangeModel(int index)
        {
            index--;
            if (index < 0 || index >= materials.Count)
            {
                Debug.LogError("index out of the range of materials!");
                return;
            }

            return;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
