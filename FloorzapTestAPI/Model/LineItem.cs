using FloorzapTestAPI.Enum;

namespace FloorzapTestAPI.Model
{
    public class LineItem
    {
        public int LineItemID { get; set; }
        public string LineItemName { get; set; } = string.Empty;
        public string LineItemDescription { get; set;} = string.Empty;
        public decimal UnitCost { get; set;}
        public decimal Quantity { get; set;}
        public decimal TotalCost { get; set;}
        public decimal Margin { get; set;}
        public decimal UnitPrice { get; set;}
        public decimal TotalPrice { get; set;}
        public bool SalesTax { get; set;}
        public LineItemType LineItemType { get; set;}
        public string? PropertyName { get; set; } 
        public decimal PropertyValue { get; set; } 
    }
}
