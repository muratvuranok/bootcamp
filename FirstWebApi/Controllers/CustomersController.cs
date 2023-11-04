namespace BootCamp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;
    public CustomersController(ApplicationDbContext context, IMapper mapper, ICustomerService customerService)
    {
        this._mapper = mapper;
        this._context = context;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //var customers = await _context.Customers.ToListAsync();

        //var dto = _mapper.Map<List<CustomerDto>>(customers);

        ////var dto = customers.Select(c => new CustomerDto
        ////{
        ////    Id = c.Id,
        ////    FirstName = c.FirstName,
        //////  Adi    = c.FirstName,
        ////    LastName = c.LastName,
        ////    Mail = c.Mail,
        ////    Phone = c.Phone
        ////}).ToList();

        //return Ok(dto);


        var customers = _mapper.Map<List<Customer>>(await _customerService.GetAsync());
        return Ok(customers);
    }


    [HttpPost]
    public async Task<IActionResult> Post(CustomerCreateDto model)
    {
        if (ModelState.IsValid)
        {
            //var customer = new Customer()
            //{
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    Phone = model.Phone,
            //    Mail = model.Mail
            //};

            var customer = _mapper.Map<Customer>(model);

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Ok(HttpStatusCode.Created);
        }

        return Ok(HttpStatusCode.BadRequest);
    }




}
