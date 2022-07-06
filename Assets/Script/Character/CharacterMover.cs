using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform character;
    public Vector3 difference;
    public Vector3 previousPos;
    public Vector3 initialPoint;
    bool isFar;

    private void OnMouseDown() {
        Vector3 pointer = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        previousPos = Camera.main.ScreenToWorldPoint(character.position);

        Debug.Log(Mathf.Abs(pointer.x - previousPos.x));
        Debug.Log(Mathf.Abs(pointer.y - previousPos.y));

        if(Mathf.Abs(pointer.x - previousPos.x) < 4 && Mathf.Abs(pointer.y - previousPos.y) < 7) isFar = false;
        else isFar = true;
        Debug.Log(isFar);
    }

    private void OnMouseDrag() {
            Vector3 pointer = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(isFar) {
            previousPos = Camera.main.ScreenToWorldPoint(character.position);
            Vector3 tempVec = previousPos.normalized;
            float a = Mathf.Abs(previousPos.x - pointer.x);
            float b = Mathf.Abs(previousPos.y - pointer.y);
            character.position = pointer + new Vector3(a*tempVec.x,b*tempVec.y,0);
        }
        else {
            character.position = pointer;
        }
        
        

    }
}
