using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    private static Player _instance;
    public static Player Instance { get { return _instance; } }

    private static int kill_counter;
    private float current_hp = 100f;
    private float max_hp = 100f;
    private float hp_regen = 0.05f;
    private bool player_dead = false;
    private Rigidbody2D rb;
    private static Animator animator;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            //Check DontDestroyOnLoad if want to persist across scenes
            //DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable() {
        GameEvents.Instance.SetPlayerMaxHp(max_hp);
    }

    void Start() {
        GameEvents.Instance.onEnemyContactTriggerEnter += EnemyContact;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        kill_counter = 0;
    }

    private void FixedUpdate() {
        if(!player_dead && current_hp < max_hp) {
            current_hp = Mathf.Min(current_hp + hp_regen, max_hp);
            GameEvents.Instance.SetPlayerHpValue(current_hp);
            GameEvents.Instance.PlayerHpChange();
        }
    }

    private void EnemyContact() {
        DoDamageToPlayer();
        //PlayerMovement.Instance.DoKnockback();

    }

    private void DoDamageToPlayer() {
        current_hp -= GameEvents.Instance.GetPlayerIncDamageValue();
        GameEvents.Instance.PlayerHpLost();
        CheckIfPlayerDead();
    }

    private void CheckIfPlayerDead() {   
        if(current_hp <= 0f) {
            animator.SetBool("Die", true);
            player_dead = true;
            // TODO die process
        }
    }

    private static void Attack(string move) { 
        /*Dictionary<string,float> skill_properties = Skills_list.skills[move];
        skill_properties.TryGetValue("mana", out float mana_cost);
        if(current_mana < mana_cost) {
            Debug.Log("Not enough mana: " + current_mana);
            Debug.Log("mana cost: " + mana_cost);
        }
        else {
            current_mana = Mathf.Max(0, current_mana - mana_cost);
            GameEvents.Instance.SetManaValue(current_mana);
            GameEvents.Instance.PlayerManaChange();
            animator.Play(move);
        }*/
    }

    public static float GetOutputDamage(string move) {
        // TODO Changes to damage depending on weapon
        return 1;
    }

    public static void ReceiveKill() {
        kill_counter += 1; 
    }

    public void Flip_Horizontal() {
        Debug.Log("ButtonClick");
        // joystick.joystickVec.x  by horizontal
        /*if(is_facing_right && joystick.joystickVec.x < 0f || !is_facing_right && joystick.joystickVec.x > 0f) {
            is_facing_right = !is_facing_right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }*/
    }
}
