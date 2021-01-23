using System.Collections.Generic;

namespace TSBAutomationExam.DataObjects
{
    public class CategoriesDO
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Path { get; set; }
        public List<SubcategoriesDO> Subcategories { get; set; }
    }

    public class SubcategoriesDO
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Path { get; set; }
        public bool HasClassifieds { get; set; }
        public int AreaOfBusiness { get; set; }
        public bool IsLeaf { get; set; }
    }
}
