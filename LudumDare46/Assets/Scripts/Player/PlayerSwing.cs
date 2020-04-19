using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public float swingDistance;
    public float hitTimeNeeded;
    private float hitTimeHave;
    private int currentItem;
    private int direction; // 1 for right -1 for left

    private ContactFilter2D filter;
    private List<RaycastHit2D> hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        hitInfo = new List<RaycastHit2D>();
        filter = new ContactFilter2D();
        filter.NoFilter();
        currentItem = 0;
        hitTimeHave = hitTimeNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        if (axis > 0) direction = 1;
        if (axis < 0) direction = -1;
        if (hitTimeHave >= hitTimeNeeded && Input.GetKeyDown(KeyCode.E))
        {
            hitTimeHave = 0;
            //Hit/Interact
            if (Physics2D.Raycast(transform.position, Vector2.right * direction, filter, hitInfo, swingDistance) != 0)
            {
                foreach (RaycastHit2D hit in hitInfo)
                {
                    Interactable ic = hit.transform.gameObject.GetComponent<Interactable>();
                    if (ic != null)
                    {
                        //Interact with the object and get the item from it
                        int item = ic.interact();
                        if (item != 0) currentItem = item;
                    }
                }
            }
        }
        else hitTimeHave += Time.deltaTime;
    }
}
