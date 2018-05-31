using System;
namespace TheProductiveFamily.Views
{
    public class MasterDetailsPageMenuItem
    {
        public MasterDetailsPageMenuItem()
        {
            TargetType = typeof(ServicesListPage);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
