using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStage : MonoBehaviour
{
    [SerializeField]
    private GameObject _stageManager;
    [SerializeField]
    private GameObject _panel;
    public void Click()
    {
        _panel.SetActive(true);
        _stageManager.GetComponent<StageRankInfo>().WrapCoroutine(this.gameObject.name);
    }
}
