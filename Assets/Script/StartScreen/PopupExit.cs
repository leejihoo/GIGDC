using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupExit : MonoBehaviour
{
    public void PopupExitBtn()
    {
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
    }
}
