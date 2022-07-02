using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickStageButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("StageScene");
    }
}
