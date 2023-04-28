﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Culture { get; set; }
    }
}
