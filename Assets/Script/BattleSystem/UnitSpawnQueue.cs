using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnQueue : MonoBehaviour
{
    private Queue<string> queue = new Queue<string>();
    private bool full = false;
    private Coroutine processingCoroutine;
    private BattleSystem battleSystem;

    public Queue<Sprite> splashArts = new Queue<Sprite>(); // Lista splash artów
    public Sprite emptySprite;


    public bool isPlayer;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isPlayer = !isPlayer;
        }

    }


    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();
        isPlayer = true;
    }

    public void AddUnit(string unitType, Sprite unitSplashArt)
    {
        if (!full)
        {
            queue.Enqueue(unitType);
            splashArts.Enqueue(unitSplashArt);

            if (queue.Count == 5)
                full = true;

            if (processingCoroutine == null)
                processingCoroutine = StartCoroutine(ProcessQueueCoroutine());
        }
    }

    private IEnumerator ProcessQueueCoroutine()
    {
        while (queue.Count > 0)
        {
            string unitType = queue.Peek();

            double cooldown = 0f;
            switch (unitType)
            {
                case "melee":
                    cooldown = battleSystem.playerMeleeCooldown;
                    break;
                case "range":
                    cooldown = battleSystem.playerRangeCooldown;
                    break;
                case "tank":
                    cooldown = battleSystem.playerTankCooldown;
                    break;
                case "healer":
                    cooldown = battleSystem.playerHealerCooldown;
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds((float)cooldown);

            Debug.Log("Tworzenie jednostki: " + unitType);
            battleSystem.spawnUnit(unitType, isPlayer);
            queue.Dequeue();
            splashArts.Dequeue();


            full = false;
        }

        processingCoroutine = null;
    }

}
