using UnityEngine;

public class PlayerStat : MonoBehaviour
{
   public int hp=100;
   [SerializeField] private int power=10;

    MonsterStat ms = new MonsterStat();
    public void Attack(int power)
    {
        this.hp -= power;
    }

    public void MonsterAttack(int power) //몬스터 체력을 깎음
    {
        ms.hp-= power;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
