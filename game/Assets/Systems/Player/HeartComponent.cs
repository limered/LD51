using UnityEngine;

namespace Systems.Player
{
    public class HeartComponent : MonoBehaviour
    {
        public GameObject healedHeart;
        public GameObject brokenHeart;
        
        public void Break()
        {
            brokenHeart.SetActive(true);
            healedHeart.SetActive(false);
        }

        public void Heal()
        {
            brokenHeart.SetActive(false);
            healedHeart.SetActive(true);
        }
    }
}