using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateOnVRSelect : MonoBehaviour
{
    public float rotationAmount = 60f;
    private XRSimpleInteractable interactable;

    void Awake()
    {
        // Add an XR interactable if it doesn't already exist
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
        {
            interactable = gameObject.AddComponent<XRSimpleInteractable>();
        }

        // Register the select event
        interactable.selectEntered.AddListener(OnVRSelect);
    }

    private void OnVRSelect(SelectEnterEventArgs args)
    {
        // Rotate the object 60 degrees around the Y axis
        transform.Rotate(0, rotationAmount, 0);
    }

    void OnDestroy()
    {
        // Clean up the event listener
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnVRSelect);
        }
    }
}