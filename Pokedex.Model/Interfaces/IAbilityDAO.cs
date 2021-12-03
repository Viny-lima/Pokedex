using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    interface IAbilityDAO
    {
        void AddAbility(AbilityDB abilityDB);
        void RemoveAbility(AbilityDB abilityDB);
        void UpdateAbility(AbilityDB abilityDB);
    }
}
