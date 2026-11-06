using System;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpbar : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private TextMeshProUGUI hpText;

    // 플레이어의 HP
    private int _hp;

    public int Hp
    {
        get => _hp;
        // HP는 PlayerController에서만 수정 하도록 private으로 처리
        // Math.Clamp 함수를 사용해서 hp가 0보다 아래로 떨어지지 않게 합니다.
        private set => _hp = Math.Clamp(value, 0, _hp);
    }

    private void Awake()
    {
        // 플레이어의 HP 값을 초기 세팅합니다.
        _hp = this.gameObject.GetComponent<PlayerStat>().hp;
        // MaxValue를 세팅하는 함수입니다.
        SetMaxHealth(_hp);
        hpText.text = $"{_hp}";
    }

    public void SetMaxHealth(int health)
    {
        _hpBar.maxValue = health;
        _hpBar.value = health;
    }

    // 플레이어가 대미지를 받으면 대미지 값을 전달 받아 HP에 반영합니다.
    public void GetDamage(int damage)
    {
        int getDamagedHp = Hp - damage;
        Hp = getDamagedHp;
        _hpBar.value = Hp;
        hpText.text = $"{_hp}";
    }
}
