using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSelectWheelScript : MonoBehaviour
{
    public Vector2 normaliseMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;

    public GameObject[] menuItems;

    private SelectionWheel menuItemSc;
    private SelectionWheel previousMenuItemSc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normaliseMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normaliseMousePosition.y, normaliseMousePosition.x) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 45;

        if(selection != previousSelection)
        {
            previousMenuItemSc = menuItems[previousSelection].GetComponent<SelectionWheel>();
            previousMenuItemSc.Deselect();
            previousSelection = selection;

            menuItemSc = menuItems[selection].GetComponent<SelectionWheel>();
            menuItemSc.Select();
        }

        //Debug.Log(selection);
    }
}
