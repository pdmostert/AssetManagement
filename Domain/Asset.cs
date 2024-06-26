﻿using System.ComponentModel.DataAnnotations;

namespace Domain;

// Represents an asset with various properties and methods
public class Asset : Entity
{
    public Asset()
    {

    }
    // Constructor
    public Asset(string name, string serialNumber)
    {
        Name = name;
        SerialNumber = serialNumber;
    }

    // Properties
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    [Required]
    public string SerialNumber { get; set; }
    public string? Category { get; set; }
    public string? SubCategory { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }

    // Computed property
    public string AssetTag => $"{Name} - {SerialNumber}";

    // Computed property
    public string AssetFullTag => $"{Name} - {SerialNumber} - {Category} - {SubCategory} - {Type} - {Status}";
}
