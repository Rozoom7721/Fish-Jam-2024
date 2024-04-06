using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILeaderHitListener
{
    void onLeaderHit(bool isPlayer, double damage);

}
