using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnockedOverItemsCounter : MonoBehaviour
{

    private void Start()
    {
        UpdateCounterText();
    }

    [System.Serializable]
    public class DoorUnlock
    {
        public Collider2D doorCollider;
        public int requiredKnocks;
        [HideInInspector] public bool opened;
    }

    [SerializeField] private DoorUnlock[] doors;
    [SerializeField] private TextMeshProUGUI counterText;

    private int knockedObjects = 0;
    private HashSet<GameObject> alreadyKnocked = new HashSet<GameObject>();


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Hit: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

        GameObject hitObject = collision.gameObject;

        if (hitObject.CompareTag("Knockable") && alreadyKnocked.Add(hitObject))
        {
            knockedObjects++;
            UpdateCounterText();

            foreach (DoorUnlock door in doors)
            {
                if (!door.opened && knockedObjects >= door.requiredKnocks)
                {
                    door.doorCollider.enabled = false;
                    door.opened = true;
                }
            }
        }
    }

    private void UpdateCounterText()
    {
        counterText.text = "Items knocked over: " + knockedObjects;
        Debug.Log("Updated text on: " + counterText.name, counterText);
    }
}