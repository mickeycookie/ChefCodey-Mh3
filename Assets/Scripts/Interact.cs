using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;

    public string triggerName = "";

    public GameObject breadPrefab;

    public GameObject heldItem;
    public string heldItemName;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                heldItem = Instantiate(breadPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0, 2, 2);
                heldItemName = "breadSlice";
                //print("Codey wants to pick up the bread!");
            }

            if (triggerName == "Stove")
            {
                if(heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    Destroy(heldItem);
                    heldItemName = "";
                }
                else
                {
                    if (stove.cookedFood == "toast")
                    {
                        heldItem = Instantiate(breadPrefab, transform, false);
                        heldItem.transform.localPosition = new Vector3(0, 2, 2);
                        heldItemName = "toastSlice";
                        stove.CleanStove();
                    }
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }
}
