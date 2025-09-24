using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] int hp;

    public void Collect(int collectionAmount, int id, Movement bec)
    {
        hp -= collectionAmount;

        if (hp <= 0)
        {
            bec.CollectGem(id);
            Destroy(gameObject);
        }

    }



}

