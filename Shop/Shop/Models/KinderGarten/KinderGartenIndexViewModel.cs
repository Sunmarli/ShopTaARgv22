using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.Models.KinderGarten

{
    public class KinderGartenIndexViewModel
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
