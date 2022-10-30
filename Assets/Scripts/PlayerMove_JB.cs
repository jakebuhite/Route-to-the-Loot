using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_JB : MonoBehaviour
{
    public Vector2 direction;
    public int spawnRange = 1;
    public float speed = 0.1f;

    // Private variables
    new private Renderer renderer;
    private float localSpeed = 0;

    // Get direction the player is facing (right by default)
    bool isFacingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Stop player from moving in certain directions
        bool blockMovingUp = false;
        bool blockMovingDown = false;
        bool blockMovingRight = false;
        bool blockMovingLeft = false;

        float halfHeight = 60;
        float halfWidth = 60;
        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        // Check to see if current position is greater than screen width
        if ((currentPosition.x + halfWidth) > Screen.width)
        {
            blockMovingRight = true;
        }
        // Check to see if current position is greater than screen height
        if (currentPosition.y + halfHeight > Screen.height)
        {
            blockMovingUp = true;
        }
        // Check to see if current position is less than 0
        if (currentPosition.x - halfWidth < 0)
        {
            blockMovingLeft = true;
        }
        // Check to see if current position is less than 0
        if (currentPosition.y - halfHeight < 0)
        {
            blockMovingDown = true;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !blockMovingUp)
        {
            direction.y = 1;
            localSpeed += speed;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !blockMovingRight)
        {
            direction.x = 1;
            localSpeed += speed;
            if (isFacingLeft)
            {
                this.transform.Rotate(0.0f, 180.0f, 0.0f);
                isFacingLeft = false;
            }
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !blockMovingLeft)
        {
            direction.x = -1;
            localSpeed += speed;
            if (!isFacingLeft)
            {
                this.transform.Rotate(0.0f, 180.0f, 0.0f);
                isFacingLeft = true;
            }
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !blockMovingDown)
        {
            direction.y = -1;
            localSpeed += speed;
        }

        if (direction != Vector2.zero)
        {
            direction.Normalize();
        }
        Mathf.Clamp(localSpeed, 0, 1.25f);
        localSpeed = Mathf.Lerp(localSpeed, 0, 0.1f);
        Vector3 newPosition = new Vector3(localSpeed * direction.x * Time.deltaTime, localSpeed * direction.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }
}
