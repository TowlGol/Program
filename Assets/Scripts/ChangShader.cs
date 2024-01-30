using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangShader : MonoBehaviour
{
    public void changeTransparent(GameObject gameObject) {
        Material[] materials = gameObject.GetComponent<Renderer>().materials;
        for(int i = 0; i < materials.Length; i++) {
            Debug.Log(i);

            //materials[i].shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
            Color color = materials[i].color;
            materials[i].color = new Color(color.r, color.g, color.b, 0.1f);
            //materials[i].color = new Color(1, 1, 1, 0.1f);
        }
    }

}
