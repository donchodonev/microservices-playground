﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageContracts
{
    public class MessageContracts
    {
        public interface IInvoiceCreated
        {
            public int InvoiceNumber { get; }

            public IInvoiceToCreate InvoiceData { get; }
        }

        public interface IInvoiceToCreate
        {
            public int CustomerNumber { get; set; }

            public List<InvoiceItems> InvoiceItems { get; set; }
        }

        public class InvoiceItems
        {
            public string Description { get; set; }

            public double Price { get; set; }

            public double ActualMileage { get; set; }

            public double BaseRate { get; set; }

            public bool IsOversized { get; set; }

            public bool IsRefrigerated { get; set; }

            public bool IsHazardousMaterial { get; set; }
        }
    }
}
