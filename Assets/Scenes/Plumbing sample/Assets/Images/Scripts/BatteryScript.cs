using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public int batteryNumber;  // Unique number for each battery (1 to 4)
    public GameObject correspondingObject; // Object to activate when battery is clicked

    public static int activatedCount = 0; // Tracks how many objects have been activated
    public static bool[] activatedBatteries = new bool[4]; // Tracks each battery's activation

    public GameObject panel;     // UI Panel to activate when all are clicked
    public GameObject nextButton; // Next button to activate when all are clicked

    void Start()
    {
        // Ensure tracking starts at zero
        activatedCount = 0;

        // Initialize tracking array
        for (int i = 0; i < activatedBatteries.Length; i++)
        {
            activatedBatteries[i] = false;
        }

        // Make sure panel & next button are disabled initially
        if (panel) panel.SetActive(false);
        if (nextButton) nextButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Activate corresponding object and deactivate clicked battery
                    if (correspondingObject) correspondingObject.SetActive(true);
                    gameObject.SetActive(false);

                    // Mark this battery as activated
                    if (!activatedBatteries[batteryNumber - 1])
                    {
                        activatedBatteries[batteryNumber - 1] = true;
                        activatedCount++;
                    }

                    // If all 4 batteries have been activated, enable the panel and next button
                    if (activatedCount == 4)
                    {
                        if (panel) panel.SetActive(true);
                        if (nextButton) nextButton.SetActive(true);
                    }
                }
            }
        }
    }
}