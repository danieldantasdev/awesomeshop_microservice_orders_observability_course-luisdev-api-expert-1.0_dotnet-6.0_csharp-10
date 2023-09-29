using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.ValueObjects;

public record PaymentInfo(string CardNumber, string FullName, string ExpirationDate, string Cvv);