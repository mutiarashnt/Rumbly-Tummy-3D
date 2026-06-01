using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2)
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                PickupItem item =
                    hit.collider.GetComponent<PickupItem>();

                Debug.Log("Picked up: " + item.itemName);

                Destroy(hit.collider.gameObject);
            }
        }
    }
}