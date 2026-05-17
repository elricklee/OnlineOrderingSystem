namespace OnlineOrdering.API.Models;

public static class DishSaleStatuses
{
    public const string OnSale = "OnSale";
    public const string OffSale = "OffSale";
    public const string OutOfStock = "OutOfStock";
}

public static class OrderTypes
{
    public const string DineIn = "DineIn";
    public const string Delivery = "Delivery";
}

public static class OrderStatuses
{
    public const string Pending = "Pending";
    public const string Confirmed = "Confirmed";
    public const string Preparing = "Preparing";
    public const string Ready = "Ready";
    public const string Delivering = "Delivering";
    public const string Completed = "Completed";
    public const string Cancelled = "Cancelled";
}

public static class DiningTableStatuses
{
    public const string Available = "Available";
    public const string Reserved = "Reserved";
    public const string Occupied = "Occupied";
    public const string Cleaning = "Cleaning";
    public const string Disabled = "Disabled";
}

public static class TableSessionStatuses
{
    public const string Open = "Open";
    public const string Closed = "Closed";
    public const string Cancelled = "Cancelled";
}

public static class UserRoles
{
    public const string Customer = "Customer";
    public const string Admin = "Admin";
    public const string Kitchen = "Kitchen";
    public const string Rider = "Rider";
    public const string SuperAdmin = "SuperAdmin";
    public const string Guest = "Guest";
}
