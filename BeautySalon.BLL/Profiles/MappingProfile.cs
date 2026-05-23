using AutoMapper;
using BeautySalon.BLL.DTOs.Appointments;
using BeautySalon.BLL.DTOs.Categories;
using BeautySalon.BLL.DTOs.Clients;
using BeautySalon.BLL.DTOs.Employees;
using BeautySalon.BLL.DTOs.EmployeeSchedules;
using BeautySalon.BLL.DTOs.EmployeeServices;
using BeautySalon.BLL.DTOs.Services;
using BeautySalon.DAL.Entities;

namespace BeautySalon.BLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CLIENT
            CreateMap<Client, ClientDto>();
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();

            // CATEGORY
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            // EMPLOYEE
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            // SERVICE
            CreateMap<Service, ServiceDto>();
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();

            // APPOINTMENT 
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.ServiceName,
                           opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.EmployeeName,
                           opt => opt.MapFrom(src =>
                               src.Employee.FirstName + " " + src.Employee.LastName));
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();

            // EMPLOYEE - SERVICE
            CreateMap<EmployeeService, EmployeeServiceDto>();
            CreateMap<CreateEmployeeServiceDto, EmployeeService>();

            // EMPLOYEE SCHEDULE
            CreateMap<EmployeeSchedule, EmployeeScheduleDto>();
            CreateMap<CreateEmployeeScheduleDto, EmployeeSchedule>();
        }
    }
}
