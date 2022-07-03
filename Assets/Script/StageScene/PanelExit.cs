using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelExit : MonoBehaviour
{
    [SerializeField]
    GameObject _panel;
    public void Click()
    {
        _panel.SetActive(false);
    }
}
