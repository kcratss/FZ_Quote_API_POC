namespace FloorzapTestAPI.Model
{
    public class Commission
    {
        public int CommissionID { get; set; }

        /// <summary>
        /// Gets or sets the BasedOn value.
        /// </summary>
        public byte BasedOn { get; set; }

        /// <summary>
        /// Gets or sets the Per value.
        /// </summary>
        public byte Per { get; set; }

        /// <summary>
        /// Gets or sets the Selection value.
        /// </summary>
        public int Selection { get; set; }

        /// <summary>
        /// Gets or sets the Value1 value.
        /// </summary>
        public decimal Value1 { get; set; }

        /// <summary>
        /// Gets or sets the Value2 value.
        /// </summary>
        public decimal Value2 { get; set; }

        /// <summary>
        /// Gets or sets the ValuesOperation value.
        /// </summary>
        public string ValuesOperation { get; set; }

        /// <summary>
        /// Gets or sets the CommissionValueType value.
        /// </summary>
        public byte CommissionValueType { get; set; }

        /// <summary>
        /// Gets or sets the CommissionValue value.
        /// </summary>
        public decimal CommissionValue { get; set; }

        /// <summary>
        /// Gets or sets the CommissionValueOperation value.
        /// </summary>
        public string CommissionValueOperation { get; set; }

        /// <summary>
        /// Gets or sets the SystemListID value.
        /// </summary>
        public int SystemListID { get; set; }

        // Foreign Key columns

        /// <summary>
        /// Gets or sets the SystemList value.
        /// </summary>
        public SystemList SystemList { get; set; }

    }
}
