using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{
    Player()
    {
        atk = 100;
        def = 80;

        GetDamage();
    }
}
