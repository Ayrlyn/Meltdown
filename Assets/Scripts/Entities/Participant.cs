using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participant : MonoBehaviour
{
    #region serializable variables
    #endregion

    #region local variables
    bool _defeated = false;
    bool _isGrounded = false;
    #endregion

    #region getters and setters
    public bool Defeated { get { return _defeated; } }
    public bool IsGrounded { get { return _isGrounded; } }
    #endregion

    #region Unity methods
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7) { _isGrounded = true; }
        if(collision.gameObject.layer == 9) { StartCoroutine(DefeatRoutine()); }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 7) { _isGrounded = false; }
    }
    #endregion

    #region local methods
    #endregion

    #region public methods
    public void Duck()
    {
        if (IsGrounded) { this.transform.localScale = new Vector3(1.5f, 0.4f, 1.5f); }
    }

    public void Jump()
    {
        this.transform.localScale = Vector3.one;
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * 250f);
    }
    #endregion

    #region Coroutines
    IEnumerator DefeatRoutine()
    {
        _defeated = true;
        while(this.transform.localScale.magnitude > (Vector3.one * 0.1f).magnitude)
        {
            this.transform.localScale *= 0.95f;
            yield return new WaitForEndOfFrame();
        }
        if (this.CompareTag("Player")) { EventMessenger.Instance.SendGameOver(false); }
        else { EventMessenger.Instance.SendCompetitorInfo(this.GetComponent<Competitor>()); }
        Destroy(this.gameObject);
    }
    #endregion
}
