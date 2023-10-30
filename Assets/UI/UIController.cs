using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Image hpBar_image;
    private float player_max_hp;

    void Start() {
        hpBar_image = gameObject.transform.Find("Health_bar").gameObject.GetComponent<Image>();
        GameEvents.Instance.onPlayerHpLost += DecreaseHpBar;
        GameEvents.Instance.onPlayerHpChange += ChangePlayerHpBar;
        player_max_hp = GameEvents.Instance.GetPlayerMaxHp();
    }

    private void DecreaseHpBar() {
        hpBar_image.fillAmount -= GameEvents.Instance.GetPlayerIncDamageValue() / player_max_hp;
    }

    private void ChangePlayerHpBar() {
        hpBar_image.fillAmount = GameEvents.Instance.GetPlayerHpValue() / player_max_hp;
    }
}
