

namespace ShopCore.Domain
{
    public class Kindergarten
    {
        public Guid? Id { get; set; }

        public string GroupName { get; set; }

        public int ChildrenCount { get; set; }

        public string KinderGartenName { get; set; }

        public string Teacher { get; set; }

     

        //only in database
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
