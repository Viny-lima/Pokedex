﻿using Microsoft.EntityFrameworkCore;
using Pokédex.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Controller
{
    public class PokemonController
    {
        PokemonContext context = new PokemonContext();


        public void StartUp()
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }

}
