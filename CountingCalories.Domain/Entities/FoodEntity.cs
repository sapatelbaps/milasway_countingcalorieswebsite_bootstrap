﻿namespace CountingCalories.Domain.Entities
{
    public class FoodEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaloriesPer100G { get; set; }
    }
}
