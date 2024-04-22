using UnityEngine;

public class MoveToRandomPoint2 : MonoBehaviour
{
    public float speed = 1.0f;
    public float returnSpeed = 1.0f;
    public float delay = 1.0f;

    private Vector3 targetPosition;

    private void Start()
    {
        // Choose a random target position
        targetPosition = new Vector3(
            Random.Range(0.0f, 10.0f),
            Random.Range(5.0f, 10.0f),
            0.0f
        );

        // Move the object to the target position
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", targetPosition,
            "time", speed,
            "easetype", iTween.EaseType.linear,
            "oncomplete", "ReturnToOriginalPosition",
            "oncompletetarget", gameObject
        ));
    }

    private void ReturnToOriginalPosition()
    {
        // Wait for a random time before returning to the original position
        float delayTime = Random.Range(delay, 2.0f * delay);
        Invoke("MoveToOriginalPosition", delayTime);
    }

    private void MoveToOriginalPosition()
    {
        // Move the object to the original position
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", transform.position,
            "time", returnSpeed,
            "easetype", iTween.EaseType.linear
        ));
    }
}