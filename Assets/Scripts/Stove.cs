using UnityEngine;

public class Stove : MonoBehaviour
{
    public GameObject toast;

    public string cookedFood = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toast.SetActive(false);
    }

    public void ToastBread()
    {
        toast.SetActive(true);
        cookedFood = "toast";
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        cookedFood = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
