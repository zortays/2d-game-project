using UnityEngine;

public class TimingBar : MonoBehaviour

{

    [Header("Slider Settings")]

    public Transform slider;           // White slider pointer

    public float speed = 2f;           // Slider speed

    public float leftLimit = -2f;      // Slider left end (localPosition.x)

    public float rightLimit = 2f;      // Slider right end

    [Header("Green Zone (0–1 normalized)")]

    public float greenStart = 0.4f;    // normalized 0–1

    public float greenEnd = 0.6f;

    private bool movingRight = true;

    private bool running = false;

    public void StartBar()

    {

        running = true;

        slider.localPosition = new Vector3(leftLimit, slider.localPosition.y, 0);

        movingRight = true;

    }

    void Update()

    {

        if (!running) return;

        // Move slider

        float posX = slider.localPosition.x;

        posX += (movingRight ? 1 : -1) * speed * Time.deltaTime;

        if (posX > rightLimit)

        {

            posX = rightLimit;

            movingRight = false;

        }

        else if (posX < leftLimit)

        {

            posX = leftLimit;

            movingRight = true;

        }

        slider.localPosition = new Vector3(posX, slider.localPosition.y, 0);

        // Check input

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))

        {

            CheckSuccess();

        }

    }

    void CheckSuccess()

    {

        running = false;

        // Convert slider x position to normalized 0–1

        float normalized = (slider.localPosition.x - leftLimit) / (rightLimit - leftLimit);

        bool success = normalized >= greenStart && normalized <= greenEnd;

        // Tell DialogueManager result

        DialogueManager dm = GetComponent<DialogueManager>();

        if (dm != null)

        {

            dm.OnTimingBarFinished(success);

        }

    }

    public void HideBar()

    {

        running = false;

    }

}
