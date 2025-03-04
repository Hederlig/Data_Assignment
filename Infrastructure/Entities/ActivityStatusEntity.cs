﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ActivityStatusEntity
    {
    [Key]
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
    }

