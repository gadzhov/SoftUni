using System;
using System.Linq;
using Gringotts.Data;

namespace Gringotts
{
    class GringottsMain
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();
            //DepositsSumForOllivanderFamily(context);
            DepositsFilter(context);
        }
        //20.
        private static void DepositsFilter(GringottsContext context)
        {
            context.WizzardDeposits
                .Where(deposit => deposit.MagicWandCreator == "Ollivander family")
                .GroupBy(deposit => deposit.DepositGroup)
                .Select(grouping => new
                {
                    DepositGroup = grouping.Key,
                    TotalAmount = grouping.Sum(s => s.DepositAmount)
                })
                .Where(arg => arg.TotalAmount < 150000)
                .OrderByDescending(arg => arg.TotalAmount)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt.DepositGroup} - {dt.TotalAmount}"));
        }

        //19.
        private static void DepositsSumForOllivanderFamily(GringottsContext context)
        {
            context.WizzardDeposits
                .Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select(gr => new
                {
                    DepositGroup = gr.Key,
                    Total = gr.Sum(i => i.DepositAmount)
                })
                .ToList()
                .ForEach(wd => Console.WriteLine($"{wd.DepositGroup } - {wd.Total}"));
        }
    }
}
