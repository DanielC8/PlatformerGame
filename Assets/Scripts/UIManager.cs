using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int health;
    [SerializeField] private Sprite knight;
    [SerializeField] private Image[] livesImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < livesImage.Length; i++)
        {
            if (i < health)
            {
                livesImage[i].sprite = knight;
            }
            else
            {
                livesImage[i].color = new Color(1, 1, 1, 0);
            }
        }
    }
}
