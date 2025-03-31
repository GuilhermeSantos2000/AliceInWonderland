using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("AttackTrigger");
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("CrouchTrigger", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("CrouchTrigger", false);
        }
    }
}
