/*
 Version 1.0
 * This is the customer entity.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Invitation
{
    public class Customer:IComparable<Customer>
    {
        private string name;
        public int user_id;
        private double latitude;
        private double longitude;

        public string Name { get{return this.name;} set{this.name = value;} }
        public int ID { get { return this.user_id; } set { this.user_id = value; } }
        public double Latitude { get{return this.latitude;} set{this.latitude = value;} }
        public double Longitude { get { return this.longitude; } set {this.longitude = value;}}

        public Customer(string _name, int _id, double _latitude, double _longitude)
        {
            this.name = _name;
            this.ID = _id;
            this.latitude = _latitude;
            this.longitude = _longitude;
        }

        public int CompareTo(Customer c)
        {
            return this.ID.CompareTo(c.ID);
        }

        public override string ToString() 
        {
            return "Customer ID: " + ID + "  Customer Name: " + Name;
        }
    }
}
