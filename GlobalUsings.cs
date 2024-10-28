global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Diagnostics;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using System.Text.Json.Serialization;
global using System.Text.RegularExpressions;
global using AutoMapper;
global using FusionTech.src.Config;
global using FusionTech.src.Database;
global using FusionTech.src.DTO;
global using static FusionTech.src.DTO.CategoryDTO;
global using static FusionTech.src.DTO.ConsoleDTO;
global using static FusionTech.src.DTO.CustomerDTO;
global using static FusionTech.src.DTO.InventoryDTO;
global using static FusionTech.src.DTO.OrderDTO;
global using static FusionTech.src.DTO.OrderedGamesDto;
global using static FusionTech.src.DTO.PaymentDTO;
global using static FusionTech.src.DTO.PersonDTO;
global using static FusionTech.src.DTO.PublisherDTO;
global using static FusionTech.src.DTO.StoreDTO;
global using static FusionTech.src.DTO.StoreEmployeeDTO;
global using static FusionTech.src.DTO.StudioDTO;
global using static FusionTech.src.DTO.SupplierDTO;
global using static FusionTech.src.DTO.SupplyDTO;
global using static FusionTech.src.DTO.SystemAdminDTO;
global using static FusionTech.src.DTO.VideoGameInfoDTO;
global using static FusionTech.src.DTO.VideoGameVersionDTO;
global using FusionTech.src.Entity;
global using FusionTech.src.Middlewares;
global using FusionTech.src.Repository;
global using FusionTech.src.Service.publisher;
global using FusionTech.src.Service.Store;
global using FusionTech.src.Services.category;
global using FusionTech.src.Services.Console;
global using FusionTech.src.Services.Customer;
global using FusionTech.src.Services.Inventory;
global using FusionTech.src.Services.order;
global using FusionTech.src.Services.Payment;
global using FusionTech.src.Services.Person;
global using FusionTech.src.Services.Publisher;
global using FusionTech.src.Services.StoreEmployee;
global using FusionTech.src.Services.Studio;
global using FusionTech.src.Services.supplier;
global using FusionTech.src.Services.supply;
global using FusionTech.src.Services.SystemAdmin;
global using FusionTech.src.Services.VideoGamesInfo;
global using FusionTech.src.Services.videoGameVersion;
global using FusionTech.src.Utils;
global using FusionTech.videoGameVersion;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Npgsql;