using UnityEngine;

public class CarouselBehavior : MonoBehaviour
{
    // Corousel Rotation speed
    [SerializeField] private float rotationSpeed = 10f;
    // list of corousel Horses
    [SerializeField] private GameObject[] corouselHorses;
    // Horse speed
    [SerializeField][Range(0, 1)] float speed = 0.3f;
    // Horse Range
    [SerializeField][Range(0, 1)] float range = 0.8f;

    private float startingYPosition = 0.5f;


    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        MoveHorsesUpAndDown();
    }

    void MoveHorsesUpAndDown()
    {
        foreach (GameObject corouselHorse in corouselHorses)
        {
            float yPos = Mathf.PingPong(Time.time * speed, 1) * range + startingYPosition;
            corouselHorse.transform.position = new Vector3(transform.position.x, yPos , transform.position.z);
        }
    }
}
