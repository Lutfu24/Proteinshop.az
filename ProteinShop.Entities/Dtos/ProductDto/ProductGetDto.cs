﻿using Core.Entities.Abstract;
using ProteinShop.Entities.Concrete;
using ProteinShop.Entities.Dtos.BrandDto;
using ProteinShop.Entities.Dtos.CatalogDto;
using ProteinShop.Entities.Dtos.ImageDto;

namespace ProteinShop.Entities.Dtos.ProductDto;

public class ProductGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Raiting { get; set; }
    public string Description { get; set; }
    public bool IsAvailability { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsNew { get; set; }
    public int BrandId { get; set; }
    public BrandGetDto Brand { get; set; }
    public int CatalogId { get; set; }
    public Catalog Catalog { get; set; }
    public List<Image> Images { get; set; }
}