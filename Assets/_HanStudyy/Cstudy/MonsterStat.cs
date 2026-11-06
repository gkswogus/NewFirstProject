using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public int hp;
    public int power;


    public GameObject player;
 
    PlayerHpbar php;
    MonsterMove mv; 
 
  

    void Start()
    {
        php = player.GetComponent<PlayerHpbar>();
        mv = this.gameObject.GetComponent<MonsterMove>();
    }
    public void monsterAttack() //플레이의 체력을 깎음
    {
        if (!mv.bx.enabled) return;
        if (mv.bx.enabled) php.GetDamage(this.power);
    }
    void Update()
    {
        
    }
}
