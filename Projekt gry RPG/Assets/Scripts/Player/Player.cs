﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public class Player
    {
        private static Player instance;
        public Inventory Inventory { get; }

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }
    }

        private Player() 
        {
            Inventory = new Inventory();
        }

    }
}