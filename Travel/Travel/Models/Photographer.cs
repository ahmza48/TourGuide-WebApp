using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class Photographer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Contact { get; set; }

    public string? PlaceName { get; set; }
}
