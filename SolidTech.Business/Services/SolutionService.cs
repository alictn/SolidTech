namespace SolidTech.Business.Services
{
    public class SolutionService : ISolutionService
    {
        //readonly değişkenlere sadece constructorda değer atanır buda onun const ile farkını beirler


        private readonly SolidTechContext _context;
        private readonly IMapper _mapper;


        public SolutionService(SolidTechContext context, IMapper mapper)//Dışardan bir SolidTechContext gönderilecek 
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddSolution(SolutionDto solutionDto)
        {
            Solution solution = new Solution
            {
                Header = solutionDto.Header,
                Content = solutionDto.Content,
                ImageIcon = solutionDto.ImageIcon,
            };

            _context.Solutions.Add(solution);
            _context.SaveChanges();

        }

        //Constructor injection'ın kuralları 
        //1)Global bir değişken tanımlanır(Clasın direk içerisinde)
        //2)Constructor içerisinde parametre olarak dışarıdan enjecte edilen değişkeni temsilen global değişken ile aynı tipte bir değişken tanımlabır 
        //3)Constructor'da gönderilen dışarıdan enjekte edilen değişken global değişkene atanır
        //4)Program.cs içerisinde kullanılan servisi WebApplication builder'a haber vermemiz gerkir 


        public List<SolutionDto> GetServices()
        {
            List<Solution> solutions = _context.Solutions.ToList();
            List<SolutionDto> solutionDtos = _mapper.Map<List<SolutionDto>>(solutions);
            return solutionDtos;
        }

        public Solution GetSolutionById(int id)
        {
            var result = _context.Solutions.FirstOrDefault(s => s.SolutionId == id);

            if (result != null)
            {
                return result;
            }

            return null;
        }

        //public List<Solution> GetServices()
        //{
        //    List<Solution> solutions = _context.Solutions.ToList();
        //    List<SolutionDto> result = new List<SolutionDto>();
        //    foreach (Solution service in solutions)
        //    {
        //        result.Add(new SolutionDto
        //        {
        //            SolutionId = service.SolutionId,
        //            Content = service.Content,
        //            Header = service.Header,
        //        })
        //    }


        //}


        #region Old
        /*
     
        public List<Service> GetServices()
        {
            SolidTechContext context = new SolidTechContext();
            context.Services.ToList();
        }


        public Service GetService(int serviceId)
        {
            SolidTechContext context = new SolidTechContext();
            context.Services.Where(x => x.ServiceId).ToList();
        } 
    
        */
        #endregion

        //Solid
    }
}

//public class ExampleService
//{
//    private readonly IMapper _mapper;

//    public ExampleService(IMapper mapper)
//    {
//        _mapper = mapper;
//    }

//    public Destination Convert(Source source)
//    {
//        // Dönüşüm yap
//        Destination destination = _mapper.Map<Destination>(source);
//        return destination;
//    }
//}

