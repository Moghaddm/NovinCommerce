﻿using System;
using System.ComponentModel.DataAnnotations;
using NovinCommerce.Products;
using Volo.Abp.Application.Dtos;

namespace NovinCm.ProductManagement.Models.Products;

[Serializable]
public class ProductCreateUpdateDto : FullAuditedEntityDto<Guid>
{
    [Required]
    [StringLength(ProductConsts.MaxNameLength, MinimumLength = ProductConsts.MinNameLength)]
    public string Name { get; set; }

    [StringLength(ProductConsts.MaxDescriptionLength, MinimumLength = ProductConsts.MinDescriptionLength)]
    public string Description { get; set; }

    public long Price { get; set; }

    [Required] public int Quantity { get; set; }

    [Required] public Guid CategoryId { get; set; }
}