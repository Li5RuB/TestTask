using Excel.Services.Services;

namespace Excel
{
    public class ProgramProcess
    {
        private readonly IParseService _parseService;
        private readonly IGenerateService _generateService;

        public ProgramProcess(IGenerateService generateService, IParseService parseService)
        {
            _generateService = generateService;
            _parseService = parseService;
        }

        public void Run()
        {
            var data = _parseService.GetDataFromExcel();
            _generateService.GenerateForms(data);
        }
    }
}
