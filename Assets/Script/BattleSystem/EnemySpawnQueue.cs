using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnQueue : MonoBehaviour
{
    private Queue<string> queue = new Queue<string>();
    private bool full = false;
    private Coroutine processingCoroutine;
    private BattleSystem battleSystem;



    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();
    }

    public void AddUnit(string unitType)
    {
        if (!full)
        {
            queue.Enqueue(unitType);


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
            battleSystem.spawnUnit(unitType, false);
            queue.Dequeue();


            full = false;
        }

        processingCoroutine = null;
    }


}
