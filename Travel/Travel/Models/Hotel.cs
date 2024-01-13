using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string? HotelName { get; set; }

    public string? OwnerName { get; set; }

    public string? Contact { get; set; }

    public string? Image { get; set; }

    public string? PlaceName { get; set; }

    public int? Rooms { get; set; }

    public int? Price { get; set; }
}
