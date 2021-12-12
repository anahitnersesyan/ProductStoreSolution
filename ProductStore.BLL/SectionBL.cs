using AutoMapper;
using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IBLL;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.Shared.DTOs;
using ProductStore.Shared.DTOs.Models;
using System.Threading.Tasks;

namespace ProductStore.BLL
{
    public class SectionBL : ISectionBL
    {
        protected readonly ISectionRepository _sectionRepository;
        protected readonly IMapper _mapper;

        public SectionBL(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<CreateSectionOutDTO> CreateSectionAsync(CreateSectionInDTO inModel)
        {
            CreateSectionOutDTO result = new CreateSectionOutDTO();

            var sectionExists = await _sectionRepository.AnyAsync(a => a.Name.ToLower() == inModel.Name.ToLower());

            if(sectionExists)
            {
                result.ErrorMessage = $"Section already exists.";
                return result;
            }

            Section section = _mapper.Map<Section>(inModel);

            await _sectionRepository.AddAsync(section);

            result.Section = _mapper.Map<SectionDTO>(section);

            return result;
        }

        public async Task<RemoveSectionOutDTO> RemoveSectionAsync(RemoveSectionInDTO inModel)
        {
            RemoveSectionOutDTO result = new RemoveSectionOutDTO();

            var section = await _sectionRepository.FindAsync(a => a.Id == inModel.Id);

            if(section == null)
            {
                result.ErrorMessage = $"No section with Id={inModel.Id} exists.";
                return result;
            }

            await _sectionRepository.RemoveAsync(section);

            return result;
        }

    }
}
