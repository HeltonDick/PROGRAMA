﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Order
    {
        #region Atributos
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        #endregion

        public Order() {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId) : this() {
            this.Id = orderId;
        }

        public Order(int orderId, Address address) : this(orderId) {
            this.ShippingAddress = address;
        }

        public bool Validade() {
            bool isValid = true;

            isValid = (this.OrderItems != null && this.OrderItems.Count > 0) && (this.Id > 0) && (this.Customer != null);
            return isValid;
        }

        public Order Retrieve(int orderId) {
            return new Order();
        }

        public List<Order> Retrieve() {
            return new List<Order>();
        }

        public void Save(Order order) {
        }
    }
}
