using AutoMapper;
using GMS.Application.DTOs.Request;
using GMS.Application.DTOs.Response;
using GMS.Domain.Entities;

namespace GMS.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer Mappings
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dest => dest.Vehicles,
                    opt => opt.MapFrom(src => src.vehicles));

            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<Vehicle, VehicleSummaryResponse>();

            // Vehicle Mappings
            CreateMap<Vehicle, VehicleResponse>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.customer != null
                        ? $"{src.customer.FirstName} {src.customer.LastName}"
                        : string.Empty));

            CreateMap<CreateVehicleRequest, Vehicle>();
            CreateMap<UpdateVehicleRequest, Vehicle>();

            // Employee Mappings
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<UpdateEmployeeRequest, Employee>();

            // ServiceOrder Mappings
            CreateMap<ServiceOrder, ServiceOrderResponse>()
                .ForMember(dest => dest.VehicleInfo,
                    opt => opt.MapFrom(src => src.Vehicle != null
                        ? $"{src.Vehicle.Year} {src.Vehicle.Make} {src.Vehicle.Model} ({src.Vehicle.LicensePlate})"
                        : string.Empty))
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Vehicle != null && src.Vehicle.customer != null
                        ? $"{src.Vehicle.customer.FirstName} {src.Vehicle.customer.LastName}"
                        : string.Empty))
                .ForMember(dest => dest.MechanicName,
                    opt => opt.MapFrom(src => src.AssignedMechanic != null
                        ? $"{src.AssignedMechanic.FirstName} {src.AssignedMechanic.LastName}"
                        : string.Empty));

            CreateMap<CreateServiceOrderRequest, ServiceOrder>();

            // ServiceItem Mappings
            CreateMap<ServiceItem, ServiceItemResponse>();
            CreateMap<CreateServiceItemRequest, ServiceItem>()
                .ForMember(dest => dest.TotalCost,
                    opt => opt.MapFrom(src => (src.LaborCost + src.PartsCost) * src.Quantity));

            // Payment Mappings
            CreateMap<Payment, PaymentResponse>();
            CreateMap<CreatePaymentRequest, Payment>();
        }
    }
}