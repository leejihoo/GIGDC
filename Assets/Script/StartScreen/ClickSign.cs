using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSign : MonoBehaviour
{
    public GameObject panel;
    public void ClickSignBtn()
    {
        panel.gameObject.SetActive(true);
    }
}
