﻿namespace AAITPayment.MyFatoorah.Model
{
    public class InitiateResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ValidationErrors { get; set; }
        public Data Data { get; set; }
    }
}
