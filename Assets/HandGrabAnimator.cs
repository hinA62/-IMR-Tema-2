using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class HandGrabAnimator : MonoBehaviour
{
    public XRBaseControllerInteractor interactor;
    private Animator animator;

    private void Start()
    {
        animator.SetBool("IsGrabbing", false);
        animator = GetComponent<Animator>();

        if (interactor != null)
        {
            interactor.selectEntered.AddListener(OnGrab);
            interactor.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDestroy()
    {
        if (interactor != null)
        {
            interactor.selectEntered.RemoveListener(OnGrab);
            interactor.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log($"{name} → GRAB detected!");
        animator.SetBool("IsGrabbing", true);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log($"{name} → RELEASE detected!");
        animator.SetBool("IsGrabbing", false);
    }

}
