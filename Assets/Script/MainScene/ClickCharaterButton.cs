using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickCharaterButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("CharaterScene");
    }
}
