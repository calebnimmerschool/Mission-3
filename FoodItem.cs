using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOOP
{
    public class FoodItem
    {
        //Create variables the will receive input and set input to the labels
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        //Create the class that will receive the parameters
        public FoodItem(string name, string category, int quantity, DateTime date)
        {
            //Set inputs to the labels
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = date;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }

    }
}
