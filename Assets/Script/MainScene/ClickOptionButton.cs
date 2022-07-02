using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickOptionButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
