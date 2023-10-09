﻿namespace Shop.Models.KinderGarten
{
    public class KinderGartenDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; }
        public float ChildrenCount { get; set; }
        public int KinderGartenName { get; set; }
        public int Teacher { get; set; }

        //database

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
