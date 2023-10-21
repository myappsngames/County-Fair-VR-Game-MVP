using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    private void Start()
    {
        XRGrabInteractable  grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingModel);
        grabInteractable.selectExited.AddListener(ShowGrabbingModel);
    }

    public void HideGrabbingModel(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand Model")
        {
            leftHandModel.SetActive(false);
        }
        else if(args.interactorObject.transform.tag == "Right Hand Model")
        {
            rightHandModel.SetActive(false);
        }
    }

    public void ShowGrabbingModel(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand Model")
        {
            leftHandModel.SetActive(true);
        }
        else if (args.interactorObject.transform.tag == "Right Hand Model")
        {
            rightHandModel.SetActive(true);
        }
    }
}
