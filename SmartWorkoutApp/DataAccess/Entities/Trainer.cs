﻿using DataAccess.Entities.BaseEntity;

namespace DataAccess.Entities;

public class Trainer : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public double? Weight { get; set; }
    public int? Age { get; set; }
    public RoleEnum Role { get; set; } = RoleEnum.Trainer;
    public List<User>? Users { get; set; }
}