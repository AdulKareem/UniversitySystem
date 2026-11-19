
using System.Collections.Generic;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;

namespace UniversitySystem.Infra.Service
{
    public class SectionService: ISectionService
    {
        private readonly ISectionRepository sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            this.sectionRepository = sectionRepository;
        }

        public List<Section> GetAllSections()
        {
            return sectionRepository.GetAllSections();
        }

        public Section? GetSectionById(decimal sectionId)
        {
            return sectionRepository.GetSectionById(sectionId);
        }

        public List<Section> GetSectionsByCourse(decimal courseId)
        {
            return sectionRepository.GetSectionsByCourse(courseId);
        }

        public decimal CreateSection(Section section)
        {
            return sectionRepository.CreateSection(section);
        }

        public void UpdateSection(Section section)
        {
            sectionRepository.UpdateSection(section);
        }

        public void DeleteSection(decimal sectionId)
        {
            sectionRepository.DeleteSection(sectionId);
        }
    }
}
