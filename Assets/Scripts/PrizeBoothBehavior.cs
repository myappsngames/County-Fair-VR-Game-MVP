using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrizeBoothBehavior : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socketInteractor;
    [Header("Tickets")]
    [SerializeField] private GameObject ringTossBoothTicket;
    [SerializeField] private GameObject testYourStrengthBoothTicket;
    [SerializeField] private GameObject dartBoothTicket;



    // Start is called before the first frame update
    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        //socketInteractor.selectEntered
    }
}
