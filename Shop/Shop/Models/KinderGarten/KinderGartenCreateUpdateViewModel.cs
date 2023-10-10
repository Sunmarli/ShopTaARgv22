namespace Shop.Models.KinderGarten
{
    public class KinderGartenCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string KinderGartenName { get; set; }
        public string Teacher { get; set; }
  
        //database
     
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        //public List<IFormFile> Files { get; set; }
        //public List<ImageToDatabaseViewModel> Image { get; set; } = new List<ImageToDatabaseViewModel>();
    }

}
