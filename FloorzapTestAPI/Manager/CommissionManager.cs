using Dapper;
using FloorzapTestAPI.Enum;
using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Manager
{
    public class CommissionManager:ICommissionManager
    {
        private readonly IRepository<Commission> repository;

        public CommissionManager(IRepository<Commission> repository)
        {
            this.repository = repository;
        }

        public async Task<SalesmanCommission> GetSalesmanCommissionAsync(decimal amount, decimal profitPercent)
        {
            SalesmanCommission salesmanCommission = new();

            var commissions = await GetCommissionsAsync();
            var commission =new Commission();
            foreach(var com in commissions)
            {
                if(com.Selection== (int)CommissionSelection.SameAsStore)
                {
                    commission = com;
                    break;
                }
                else if(com.BasedOn == (int) CommissionBasedOn.Profit || com.BasedOn == (int)CommissionBasedOn.Sales || com.BasedOn == (int)CommissionBasedOn.TotalSales)
                {
                    commission = commissions.FirstOrDefault(c =>
                     (c.Selection == (int)CommissionSelection.LessThan && profitPercent < c.Value1) ||
                     (c.Selection == (int)CommissionSelection.GreaterThan && profitPercent > c.Value1) ||
                     (c.Selection == (int)CommissionSelection.Between && profitPercent >= c.Value1 && profitPercent <= c.Value2)
                    );

                    break;
                }
            }

            if (commission == null)
            {
                return salesmanCommission;
            }

            if(commission.Selection == (int)CommissionSelection.SameAsStore)
            {
                salesmanCommission.CommissionAmount = amount * (profitPercent / 100);
                salesmanCommission.CommissionPercent = profitPercent;
            }
            else if(commission.CommissionValueOperation == "%")
            {
                salesmanCommission.CommissionAmount = amount * (commission.CommissionValue / 100);
                salesmanCommission.CommissionPercent = commission.CommissionValue;
            }
            else
            {
                salesmanCommission.CommissionAmount = (commission.CommissionValue / amount) * 100;
                salesmanCommission.CommissionPercent = commission.CommissionValue;
            }

            return salesmanCommission;
        }



        public async Task<IEnumerable<Commission>> GetCommissionsAsync()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@IsStaff", 1);

            return await repository.ExecuteSPAsync<SystemList>("CommissionSelectAllWithSystemList", vParams, (commission, systemlist) => { commission.SystemList = systemlist; return commission; }, "SystemListID");
        }


        

    }
}
