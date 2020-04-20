using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public Sprite[] toolSprites;
    public GameObject tool;
    private SpriteRenderer toolRenderer;
    public float swingDistance;
    public float hitTimeNeeded;
    private float hitTimeHave;
    private Item currentItem;
    private int direction; // 1 for right -1 for left
	private bool updatePaused = false;

    public GameObject toolRSpot;
    public GameObject toolLSpot;

    private ContactFilter2D filter;
    private List<RaycastHit2D> hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        toolRenderer = tool.GetComponent<SpriteRenderer>();
        direction = 1;
        hitInfo = new List<RaycastHit2D>();
        filter = new ContactFilter2D();
        filter.NoFilter();
        currentItem = Item.None;
        hitTimeHave = hitTimeNeeded;
		updateToolRender();
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        if (axis > 0) direction = 1;
        if (axis < 0) direction = -1;
        updateToolRender();
        if (hitTimeHave >= hitTimeNeeded && Input.GetKeyDown(KeyCode.E))
        {
            if (this.currentItem != Item.None) StartCoroutine(swingTool());
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
                        Item item = ic.interact(currentItem);
                        if (item != Item.Current) currentItem = item;
                        updateToolRender();
                    }
                }
            }
        }
        else hitTimeHave += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Throw item
            currentItem = Item.None;
            updateToolRender();
			EventManager.placeToolbox();
			EventManager.placeMop();
        }
    }
	
    IEnumerator swingTool()
    {
		updatePaused = true;
        toolRenderer.flipY = true; //Swing it

        //wait a second to flip back
        yield return new WaitForSeconds(0.4f);
		updatePaused = false;
        toolRenderer.flipY = false;
    }

    void updateToolRender()
    {
        if (direction > 0)
        {
            toolRenderer.flipX = false;
            tool.transform.position = toolRSpot.transform.position;
        }
        else
        {
            toolRenderer.flipX = true;
            tool.transform.position = toolLSpot.transform.position;
        }

		if (!updatePaused)
		{
			switch(currentItem)
			{
				case Item.None:
					toolRenderer.sprite = null;
					break;
				case Item.Tools:
					toolRenderer.sprite = toolSprites[0];
					break;
				case Item.Mop:
					toolRenderer.sprite = toolSprites[1];
					break;
				case Item.Current:
					break;
				default:
					break;
			}
        }
    }
}
