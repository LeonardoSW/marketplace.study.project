﻿namespace Marketplace.Domain.Models.Commons
{
    public class NewOrderCommon
    {
        public string Cpf { get; set; }
        public List<long> ProductIds { get; set; }
    }
}
