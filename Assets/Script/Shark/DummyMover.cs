using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyMover : MonoBehaviour
{
    public float speed;

    public GameObject bullet;
    public Transform launchPoint;

    private VirtualJoystick joystick;    

    void Awake() {        
        joystick = GameObject.FindObjectOfType<VirtualJoystick>();
    }

    private void Start() {
        StartCoroutine(Shoot());
    }

    void FixedUpdate() {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) {
            MoveControl();            
        }
    }
        
    private void MoveControl() {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += upMovement;
        transform.position += rightMovement;
    }

    public IEnumerator Shoot() {
        while(true) {
            GameObject newBullet = GameObject.Instantiate(bullet);
            newBullet.transform.position = launchPoint.position;
            newBullet.transform.Translate(0,0,1);
            yield return new WaitForSeconds(0.35f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        StageClearInfo stageClearInfo = new StageClearInfo() { stageId = StageNumber.CurrentStage, isClear = false, bestScore = 0 };
        if (other.tag.Contains("Lion") || other.tag.Contains("Cat") || other.tag.Contains("Shark") || other.tag.Contains("Eagle")) {
            GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>().Wrap(stageClearInfo);
            Debug.Log("GameOVer!!!!");
        }
    }

}
