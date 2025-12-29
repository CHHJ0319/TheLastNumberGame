using Actor;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Hand playerHand;
    [SerializeField] private Hand aiHand;

    private void Awake()
    {
        Events.PlayerEvents.OnPlayerTurnStarted += CreatePlayerHand;
    }

    public void CreatePlayerHand(int curNum)
    {
        StartCoroutine(playerHand.CreateHand(curNum));
    }

}
