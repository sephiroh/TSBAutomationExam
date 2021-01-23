using System;
using System.Collections.Generic;
using System.Text;

namespace TSBAutomationExam.DataObjects
{
    public class ListingsDO
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<ListDO> List { get; set; }
        public List<FoundCategoriesDO> FoundCategories { get; set; }
    }

    public class ListDO
    {
        public string Title { get; set; }
        public string NumberPlate { get; set; }
        public int Odometer { get; set; }
        public string ExteriorColour { get; set; }
        public int Doors { get; set; }
        public string BodyStyle { get; set; }
        public int Seats { get; set; }
        public string Fuel { get; set; }
        public int Cylinders { get; set; }
        public int EngineSize { get; set; }
        public string Transmission { get; set; }
        public int Owners { get; set; }
        public string RegistrationExpires { get; set; }
        public string WofExpires { get; set; }
        public string ModelDetail { get; set; }
    }

    public class FoundCategoriesDO
    {
        public int Count { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsLeaf { get; set; }
    }
}
