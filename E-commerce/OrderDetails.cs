using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce
{
    /// <summary>
    /// DataType OrderStatus used to Slect a instance of <see cref="OrderDetails"/>
    /// </summary>
    public  enum OrderStatus{
        Default,
        Ordered,
        Cancelled
    }
     //Class 
    /// <summary>
    /// Class OrderDetails used to create instance for student <see cref="OrderDetails"/>
    /// </summary>
    public class OrderDetails
    {
        // Field
        /// <summary>
        /// static field s_id used to autoincreamentation of the OrderID
        /// </summary>
        private static int s_id=1000;
        // Property
        /// <summary>
        /// OrderID property used to store the OrderID
        /// </summary>
        /// <value></value>
        public string OrderID { get; } // Read Only
        /// <summary>
        /// CustomerID property used to store the CustomerID
        /// </summary>
        /// <value></value>
        public string CustomerID { get; set; }
        /// <summary>
        /// ProductID property used to store the ProductID
        /// </summary>
        /// <value></value>
        public string ProductID { get; set; }
        /// <summary>
        /// TotalPrice property used to store the TotalPrice
        /// </summary>
        /// <value></value>
        public float TotalPrice { get; set; }
        /// <summary>
        /// PurchaseDate property used to store the Date Of Purchase
        /// </summary>
        /// <value></value>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Quantinty property used to store the product quantity
        /// </summary>
        /// <value></value>
        public int Quantity { get; set; }
        /// <summary>
        /// OrderStatus property used to store the OrderStatus
        /// </summary>
        /// <value></value>
        public OrderStatus OrderStatus { get; set; }
        // constructor
        public OrderDetails(){}
        /// <summary>
        /// OrderDetails Constructor is used to Assign the Default value to the Property
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="totalPrice"></param>
        /// <param name="purchaseDate"></param>
        /// <param name="quantity"></param>
        /// <param name="orderStatus"></param>
        public OrderDetails(string customerId,string productId,float totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {

            // Auto increamentation
            s_id++;
            // Assigning value to property
            OrderID="OID"+s_id;
            CustomerID=customerId;
            ProductID=productId;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;
        }
        
    }
}