using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;

    public string triggerName = "";

    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;

    public GameObject heldItem;
    public string heldItemName;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                PickUpItem(breadPrefab, "breadSlice");
                //heldItem = Instantiate(breadPrefab, transform, false);
                //heldItem.transform.localPosition = new Vector3(0, 2, 2);
                //heldItemName = "breadSlice";
                //print("Codey wants to pick up the bread!");
            }

            if (triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
            }

            if (triggerName == "Stove")
            {
                if(heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    PlaceHeldItem();
                }
                else if (heldItemName == "egg")
                {
                    stove.FryEgg();
                    PlaceHeldItem();
                }
                else
                {
                    if (stove.cookedFood == "toast")
                    {
                        PickUpItem(breadPrefab, "toastSlice");
                        stove.CleanStove();
                        //heldItem = Instantiate(breadPrefab, transform, false);
                        //heldItem.transform.localPosition = new Vector3(0, 2, 2);
                        //heldItemName = "toastSlice";
                    }
                    if (stove.cookedFood == "friedEgg")
                    {
                        PickUpItem(friedEggPrefab, "friedEgg");
                        stove.CleanStove();
                    }
                }
            }

            if (triggerName == "Receivers")
            {
                //print("I'm ready to make a dish!");
                if (heldItemName == "toastSlice")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
                }
            }
        }

    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItemName = itemName;
    }
}
