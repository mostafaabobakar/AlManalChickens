﻿namespace AAITPayment.STCPAY.Model
{
    public class RefundPaymentRequestMessage
    {
        public string STCPayRefNum { get; set; }
        public int Amount { get; set; }
    }
}