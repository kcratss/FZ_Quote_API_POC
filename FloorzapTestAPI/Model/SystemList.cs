namespace FloorzapTestAPI.Model
{
    public class SystemList
    {
        /// <summary>
		/// Gets or sets the SystemListID value.
		/// </summary>
		public int SystemListID { get; set; }

        /// <summary>
        /// Gets or sets the Title value.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the ListTypeID value.
        /// </summary>
        public int ListTypeID { get; set; }

        /// <summary>
        /// Gets or sets the ReadOnly value.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the WastePercent value.
        /// </summary>
        public decimal WastePercent { get; set; }
        public int Active { get; set; }
        public string Description { get; set; }
        public decimal DefaultCost { get; set; }
        public string Abbreviation { get; set; }
        public decimal JobDownPayment { get; set; }
        public string ListTypeName { get; set; }
        public int ServiceTypeID { get; set; }
    }
}
