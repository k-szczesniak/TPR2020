﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class DataService
    {
        DataRepository _dataRepository;

        public DataService(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //TODO: Dodać metody
        //TODO: Odnośnie całego projektu - czy dodawać id i inne atrybuty? Sprawdzanie spójności, testy
    }
}