using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    private static GameEvents _instance;
    public static GameEvents Instance { get { return _instance; } }

    //TODO   Instantiate private values?????
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            //Check DontDestroyOnLoad if want to persist across scenes
            //DontDestroyOnLoad(gameObject);
        }
    }

    private Vector3 enemy_in_contact_position;
    private float knockback_force;
    public event Action onEnemyContactTriggerEnter;
    public void EnemyContactTriggerEnter() { if(onEnemyContactTriggerEnter != null) { onEnemyContactTriggerEnter(); } }
    public Vector3 GetEnemyInContactPosition() { return enemy_in_contact_position; }
    public void SetEnemyInContactPosition(Vector3 enemy_position) { enemy_in_contact_position = enemy_position; }
    public float GetEnemyKnockBackForce() { return knockback_force; }
    public void SetEnemyKnockBackForce(float force) { knockback_force = force; }


    //lock mechanism for this?
    private float player_damage_value;
    public event Action onPlayerHpLost;
    public void PlayerHpLost() { if(onPlayerHpLost != null) { onPlayerHpLost(); } }
    public float GetPlayerIncDamageValue() { return player_damage_value; }
    public void SetPlayerIncDamageValue(float damage) { player_damage_value = damage; }

    private float player_hp;
    public event Action onPlayerHpChange;
    public void PlayerHpChange() { if(onPlayerHpChange != null) { onPlayerHpChange(); } }
    public float GetPlayerHpValue() { return player_hp; }
    public void SetPlayerHpValue(float hp) { player_hp = hp; }


    private float player_max_hp;
    public event Action onPlayerMaxHp;
    public void PlayerMaxHp() { if(onPlayerMaxHp != null) { onPlayerMaxHp(); } }
    public float GetPlayerMaxHp() { return player_max_hp; }
    public void SetPlayerMaxHp(float max_hp) { player_max_hp = max_hp; }


    private float enemy_damage_value;
    public event Action onEnemyHpLost;
    public void EnemyHpLost() { if(onEnemyHpLost != null) { onEnemyHpLost(); } }
    public float GetEnemyIncDamageValue() { return enemy_damage_value; }
    public void SetEnemyIncDamageValue(float damage) { enemy_damage_value = damage; }

}
