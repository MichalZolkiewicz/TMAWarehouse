﻿namespace TMAWarehouse.DataAccess.Entites;

public class Request : BaseEntity
{
    public User User { get; set; }

    public string UserName { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public string UnitOfMeasurement { get; set; }

    public int Quantity { get; set; }

    public double NetPrice { get; set; }

    public string? Comment { get; set; }

    public string? Status { get; set; }
}
