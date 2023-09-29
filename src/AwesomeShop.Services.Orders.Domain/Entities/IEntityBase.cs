using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Entities;

public interface IEntityBase
{
    Guid Id { get; }
}