using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.XR.HandsAnimations
{
    internal class HandsAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private InputActionProperty triggerAnimationAction;
        [SerializeField] private InputActionProperty gripAnimationAction;

        public static readonly int Grip = Animator.StringToHash("Grip"); 
        public static readonly int Trigger = Animator.StringToHash("Trigger");

        private void Update()
        {
            animator.SetFloat(Grip, gripAnimationAction.action.ReadValue<float>());
            animator.SetFloat(Trigger, triggerAnimationAction.action.ReadValue<float>()); 
        }

    }
}
