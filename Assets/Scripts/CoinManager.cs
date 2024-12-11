using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject door;
    private bool doorDestroyed;
    void Start()
    {

    }

   
    void Update()
    {
        coinText.text = ": " + coinCount.ToString();

        if(coinCount == 12 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);

        }
    }
}

