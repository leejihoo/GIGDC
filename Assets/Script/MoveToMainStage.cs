using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMainStage : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("MainScene");
    }
}
