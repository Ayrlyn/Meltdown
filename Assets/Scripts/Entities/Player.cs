using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Participant
{
    #region unity methods
    void Update()
    {
        if (Defeated) { return; }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton(1)) { Duck(); }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            if (IsGrounded) { Jump(); }
        }
        else { this.transform.localScale = Vector3.one; }
    }
    #endregion
}
