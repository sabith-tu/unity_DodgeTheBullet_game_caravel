using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAnimationOffWithDelay : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float punchForce;
    private bool isPunched = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("AnimatorOffIn1S")]
    public void AnimatorOffIn1S()
    {
        //Invoke(nameof(RagdollPush), 0.3f);
        if (isPunched == false)
        {
            isPunched = true;
            StartCoroutine(RagdollPush());
        }
    }


    private void Start()
    {
        CharacterJoint[] characterJoint = GetComponentsInChildren<CharacterJoint>();

        foreach (CharacterJoint _characterJoint in characterJoint)
        {
            _characterJoint.enableProjection = true;
            //_characterJoint.enableProjection = false;
        }
    }

    


    IEnumerator RagdollPush()
    {
        yield return new WaitForSecondsRealtime(3f);
        Debug.Log("Invoking");
        _animator.enabled = false;

        // _animator.GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>()
        //     .AddForce(
        //         (Vector3.forward * punchForce) +
        //         (Vector3.down * punchForce * 0.5f)
        //         //+ (Vector3.right * punchForce * 0.00f)
        //         , ForceMode.VelocityChange);


        _animator.GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>().velocity = Vector3.zero;
        _animator.GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>()
            .AddForce(Vector3.forward * punchForce,ForceMode.Impulse);

        //_animator.GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>().AddForce(Vector3.forward * punchForce);
        //_animator.GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>().AddForce(Vector3.forward * punchForce   , ForceMode.VelocityChange);
        //_animator.GetBoneTransform(HumanBodyBones.Hips)
        //GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * punchForce);
        //GetComponentInChildren<Rigidbody>().AddForce(-transform.forward * punchForce , ForceMode.Impulse);


        //Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        //foreach (Rigidbody rigidbody in rigidbodies)
        //{
            /*
            rigidbody.AddForce((Vector3.forward * punchForce * Time.fixedUnscaledDeltaTime * 100) 
                               +
                               //Vector3.down * punchForce * 0.5f 
                               (Vector3.down * punchForce * 0.1f * Time.fixedUnscaledDeltaTime * 100)
                               //+ Vector3.right * punchForce * 0.12f
                               + 
                               Vector3.right * punchForce * 0.00f * Time.fixedUnscaledDeltaTime * 100
                ,ForceMode.VelocityChange);
                */


            //ForceMode.Impulse);
        //}
    }
}