using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSign : MonoBehaviour
{
    public void ClickSignBtn()
    {
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
    }
}
