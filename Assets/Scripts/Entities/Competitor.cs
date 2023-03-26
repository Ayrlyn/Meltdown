using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitor : Participant
{
    #region serializable variables
    #endregion

    #region local variables
    bool _ducking;
    float _failureChance;
    #endregion

    #region Unity methods
    void Update()
    {
        if (Defeated) { return; }
        if (_ducking) {  
            Duck();  }
        else { this.transform.localScale = Vector3.one; }
    }

    void OnTriggerEnter(Collider other)
    {
       if( other.CompareTag("UpperArm") && Random.Range(0, 100) > _failureChance){ _ducking = true; }
       if (other.CompareTag("LowerArm") && IsGrounded && Random.Range(0, 100) > _failureChance) 
        { 
            Jump();
            IncreaseFailureChance();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("UpperArm")){ 
            _ducking = false;
            IncreaseFailureChance();
        }
    }
    #endregion

    #region local methods
    void IncreaseFailureChance()
    {
        _failureChance += Random.Range(0f, 1f);
    }
    #endregion
}
