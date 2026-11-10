using UnityEngine;

public class TempMove : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(
            horizontal * speed,
            0,
            vertical * speed);
    }

}
