using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingController : MonoBehaviour
{
    public void DisPlayClipping(GameObject gameObject) {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
