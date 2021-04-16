//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

using static System.Tuple;
using static System.ValueTuple;

namespace ConsoleApp19
{
	public class Demo
    {
    private List<Order> OrdersforProcessing = new List<Order>();

    public void Main()
        {
            var OrderswithDiscounts = OrdersforProcessing.Select((x) => GetOrderwithDiscount(x, GetDiscountRules()));
        }
           
       public Order GetOrderwithDiscount(Order R, List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> Rules)
        {
        	var discount = Rules.Where((a) => a.QualifyingCondition(R)).Select((b) => b.GetDiscount(R)).OrderBy((x) => x).Take(3).Average();
            var neworder = new Order(R);
            neworder.Discount = discount;
        	return neworder;
        }

       public List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)>  GetDiscountRules()
        {
            List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> DiscountRules 
              = new List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)>
            { ((isAQualified, A)),
              ((isBQualified, B)),
              ((isCQualified, C)) };

            return DiscountRules;
        }
      
        
        
        
        public bool isAQualified(Order r)
        {
            return true;
        }
        public decimal A(Order r)
        {

            return 1M;
        }
        public bool isBQualified(Order r)
        {
            return true;
        }
        public decimal B(Order r)
        {

            return 1M;
        }
        public bool isCQualified(Order r)
        {
            return true;
        }
        public decimal C(Order r)
        {

            return 1M;
        }


    }


	public class Order
	{
		public Order(Order orderdata)
		{

		}
		public decimal Discount;

	}


}