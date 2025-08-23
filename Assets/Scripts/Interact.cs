using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("Space!");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
