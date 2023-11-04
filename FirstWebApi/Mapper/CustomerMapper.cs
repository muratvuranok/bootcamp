namespace BootCamp.Mapper;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        //CreateMap<Customer, CustomerDto>();
        //CreateMap<CustomerDto, Customer>();


        //CreateMap<CustomerCreateDto, Customer>();
        //CreateMap<Customer, CustomerCreateDto>();


        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.Adi, src => src.MapFrom(s => s.FirstName.ToLower()))
            .ForMember(d => d.LastName, src => src.MapFrom(s => s.LastName.ToUpper()))
            .ForMember(d => d.FullName, src => src.MapFrom(s => $"{s.FirstName} {s.LastName}"))
            .ReverseMap();
        CreateMap<Customer, CustomerCreateDto>().ReverseMap();
    }
}
