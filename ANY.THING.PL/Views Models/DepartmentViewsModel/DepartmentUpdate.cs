namespace Project.PresentionLayer.Views_Models.DepartmentViewsModel
{
    public class DepartmentUpdate
    {
  
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly CreateAt { get; set; } 

    }
}
