﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.Uebungen.BankingApp.Model
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Password { get; set; }

        [Ignore]
        public string Fullname
        {
            get
            {
                return $"{Vorname} {Nachname}";
            }
        }
    }
}
