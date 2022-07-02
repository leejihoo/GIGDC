using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickInventory : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("InventoryScene");
    }
}
