﻿using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.Entities.Copon
{
    public class Copon
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }// عدد المستفيدين 
        public int CountUsed { get; set; }// عدد استخدام الكوبون 
        public DateTime Expirdate { get; set; }// تاريخ انتهاء الخصم
        public string CoponCode { get; set; } // 
        public double Discount { get; set; }// نسبه ياعنى 20% 
        public double limtDiscount { get; set; } //حد اقصى للخصم مثلا 50 ريال
        public bool IsActive { get; set; }// يعامل معامله الحذف 
        public bool IsDeleted { get; set; }// يعامل معامله الحذف 
        public DateTime Date { get; set; } = DateTime.Now;


        public virtual ICollection<CoponUsed> CoponUseds { get; set; }

    }
}
