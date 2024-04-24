using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce
{
     //Class 
    /// <summary>
    /// Class ProductDetails used to create instance for student <see cref="ProductDetails"/>
    /// </summary>
    public class ProductDetails
    {
        // field
        /// <summary>
        /// static field s_id used to AutoIncreamentation of the ProductID
        /// </summary>
        private static int s_id=100;
        //property
        /// <summary>
        /// ProductID property used to store the ProductID
        /// </summary>
        /// <value></value>
        public string ProductID { get; set; }
        /// <summary>
        /// ProductName property used to store the ProductName
        /// </summary>
        /// <value></value>
        public string ProductName { get; set; }
        /// <summary>
        /// Price property used to store the Pric eof Product
        /// </summary>
        /// <value></value>
        public float Price { get; set; }
        /// <summary>
        /// Stock property used to store the Available Stock
        /// </summary>
        /// <value></value>
        public int Stock { get; set; }
        /// <summary>
        /// ShippingDuration property used to store the Shii=ppingDuration
        /// </summary>
        /// <value></value>
        public int ShippingDuration { get; set; }
        // constructor
        /// <summary>
        /// ProductDetails Constructor used to assign the Default value to the property.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="stock"></param>
        /// <param name="price"></param>
        /// <param name="shippingDuration"></param>
        public ProductDetails(string productName,int stock,float price,int shippingDuration)
        {
            s_id++;
            ProductID="PID"+s_id;
            ProductName=productName;
            Price=price;
            Stock=stock; 
            ShippingDuration=shippingDuration;
        }
        
    }
}