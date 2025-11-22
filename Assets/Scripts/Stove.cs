using UnityEngine;

public class Stove : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject toast;
    public GameObject friedEgg;

    [Header("Inventory")]
    public string cookedFood = "";
    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
    }

    public void ToastBread()
    {
        isCooking = true;
        smoke.Play();
        toast.SetActive(true);
        cookedFood = "toast";
        Invoke("CompleteCooking", 6f); 
    }

    public void FryEgg()
    {
        isCooking = true;
        smoke.Play();
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
        Invoke("CompleteCooking", 8f);
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
        cookedFood = "";
        complete.Stop();
    }

    private void CompleteCooking()
    {
        isCooking = false;
        smoke.Stop();
        complete.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
